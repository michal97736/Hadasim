import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import MemberModel from '../models/MemberModel';
import { MemberService } from '../services/member.service';
import { ActivatedRoute, Data, Router } from '@angular/router';
import CovidDetailsModel from '../models/CovidDetailsModel';
import VaccinationModel from '../models/VaccinationModel';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
  styleUrls: ['./add-member.component.scss']
})
export class AddMemberComponent {

  memberForm: FormGroup;
  submitted = false;
  isAddCovid: boolean = false
  isAddVaccination: boolean = false
  isEditMember: boolean = false
  i: number
  member: MemberModel
  title: string
  constructor(public memberSer: MemberService, private formBuilder: FormBuilder, public router: Router, public route: ActivatedRoute) { }

  ngOnInit() {
    //קבלת אינדיקטור האם נמצאים במצב של עריכה או הוספה
    this.route.queryParams.subscribe(params => {
      this.isEditMember = params['isEdit'];
      this.i = params['index']
    });

    //טיפול במקרה של עריכה
    if (this.isEditMember && this.i) {
      this.title = "שמירת שינויים"

      this.memberSer.getById(this.memberSer.members[this.i].idMember).subscribe(succ => {
        this.member = succ
        console.log("members-NgOnInit", this.member)
        this.setObjectOfMember()
      },
        err => {
          alert("error occures")
        }
      )

      this.memberForm = this.formBuilder.group({
        firstName: [this.memberSer.members[this.i].firstName, Validators.required],
        lastName: [this.memberSer.members[this.i].lastName, Validators.required],
        tz: [this.memberSer.members[this.i].tz, Validators.required],
        city: [this.memberSer.members[this.i].city, Validators.required],
        street: [this.memberSer.members[this.i].street, Validators.required],
        numBuilding: [this.memberSer.members[this.i].numBuilding, Validators.required],
        dateOfBitrth: ['', Validators.required],
        phone: [this.memberSer.members[this.i].phone, Validators.required],
        mobilePhone: [this.memberSer.members[this.i].mobilePhone, Validators.required],
        covidDetails: this.formBuilder.group({
          dateOfPositiveResult: [''],
          dateOfRecovery: ['']
        }, { validators: this.dateValidation }),
        vaccinations: this.formBuilder.array([])
      });
      this.memberForm.get('dateOfBitrth').setValue(this.removeTimeFromDate(this.memberSer.members[this.i].dateOfBitrth.toString()))

    }

    //טיפול במקרה של הוספה
    else {
      this.title = "שמירה"
      this.memberForm = this.formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        tz: [null, Validators.required],
        city: ['', Validators.required],
        street: ['', Validators.required],
        numBuilding: [null, Validators.required],
        dateOfBitrth: [null, Validators.required],
        phone: ['', Validators.required],
        mobilePhone: ['', Validators.required],
        covidDetails: this.formBuilder.group({
          dateOfPositiveResult: [''],
          dateOfRecovery: ['']
        }, { validators: this.dateValidation }),
        vaccinations: this.formBuilder.array([])
      });
    }
  }


  get vaccinations() {
    return (<FormArray>this.memberForm.get('vaccinations')).controls
  }

  //קבלת נתוני האוביקטים הפנימיים של חבר הקופה והכנסתם לטופס
  setObjectOfMember() {
    if (this.member.covidDetails) {
      this.memberForm.get('covidDetails').get('dateOfPositiveResult').setValue(this.removeTimeFromDate(this.member.covidDetails.dateOfPositiveResult.toString()))
      this.memberForm.get('covidDetails').get('dateOfRecovery').setValue(this.removeTimeFromDate(this.member.covidDetails.dateOfRecovery.toString()))
    }
    if (this.member.vaccinations) {
      this.member.vaccinations.forEach(m => {
        const vaccinationForm = this.formBuilder.group({
          manufacturer: [m.manufacturer],
          dateOfReceivingVaccine: [this.removeTimeFromDate(m.dateOfReceivingVaccine.toString())]
        })
        this.vaccinations.push(vaccinationForm)
      })
    }
  }

  //הוספתחיסון למערך באופן דינאמי
  addVaccinationToArray(): void {
    if (this.vaccinations.length < 4) {
      const vaccinationForm = this.formBuilder.group({
        manufacturer: [''],
        dateOfReceivingVaccine: ['']
      })
      this.vaccinations.push(vaccinationForm)
    }
    else
      alert("אפשר להוסיף עד ארבעה חיסונים")
  }

  //ולידציה על תאריך
  dateValidation(group: FormGroup) {
    const dateOfPositiveResult = group.get('dateOfPositiveResult').value;
    const dateOfRecovery = group.get('dateOfRecovery').value;
    if (dateOfPositiveResult && dateOfRecovery) {
      return dateOfPositiveResult < dateOfRecovery ? null : { datesInvalid: true };
    }
    return null;
  }

  removeTimeFromDate(dateString: string): string {
    const dateParts = dateString.split('T');
    return dateParts[0];
  }

  //הוספת פרטי קורונה
  addCovid() {
    this.isAddCovid = true
  }

  //הוספת חיסונים
  addVaccination() {
    this.isAddVaccination = true
  }

  //פונקציה שמירה טיפול בכל המקרים עריכה \הוספה וכו 
  onSubmit() {
    let memberToAdd: MemberModel = new MemberModel(0, this.memberForm.value.firstName, this.memberForm.value.lastName, this.memberForm.value.tz, this.memberForm.value.city,
      this.memberForm.value.street, this.memberForm.value.numBuilding, this.memberForm.value.dateOfBitrth, this.memberForm.value.phone, this.memberForm.value.mobilePhone,
      null,
      null)

    if (this.isEditMember) {
      debugger
      memberToAdd.idMember = this.member.idMember

      if (this.member.covidDetails) {
        memberToAdd.covidDetails.id = this.member.covidDetails.id
        memberToAdd.covidDetails.idMember = this.member.idMember

      }
      else {
        memberToAdd.covidDetails = null
      }
      if (this.member.vaccinations.length != 0) {
        memberToAdd.vaccinations = []
        this.vaccinations.forEach((m, i) => {
          memberToAdd.vaccinations.push(new VaccinationModel(this.member.vaccinations[i].id, this.member.idMember, m.value.dateOfReceivingVaccine, m.value.manufacturer))
        })
      }
      else {
        memberToAdd.vaccinations = []
        this.vaccinations.forEach((m, i) => {
          memberToAdd.vaccinations.push(new VaccinationModel(0, this.member.idMember, m.value.dateOfReceivingVaccine, m.value.manufacturer))
        })
      }

      this.memberSer.updateMember(this.member.idMember, memberToAdd).subscribe(succ => {
        alert("עודכן בהצלחה")
        this.router.navigate(['/showMember'])
        console.log('Member model ', succ);

      },
        err => {
          alert("הרחשה שגיאה")
        })
    }

    else {


      if (this.memberForm.value.covidDetails.dateOfPositiveResult != '' && this.memberForm.value.covidDetails.dateOfRecovery != '')
        memberToAdd.covidDetails = new CovidDetailsModel(0, 1, this.memberForm.value.covidDetails.dateOfPositiveResult, this.memberForm.value.covidDetails.dateOfRecovery)
      if (this.vaccinations.length > 0)
        memberToAdd.vaccinations = []
      this.vaccinations.forEach(m => {
        memberToAdd.vaccinations.push(new VaccinationModel(0, 1, m.value.dateOfReceivingVaccine, m.value.manufacturer))
      })
      this.memberSer.addMember(memberToAdd).subscribe(succ => {
        memberToAdd = succ;
        console.log('Member model added successfully:-succ', memberToAdd);
        alert(" נוסף בהצלחה!")
        this.router.navigate(['/showMember'])

      },
        err => {
          alert("התרחשה שגיאה בהוספה")
        })

    }
  }
}
