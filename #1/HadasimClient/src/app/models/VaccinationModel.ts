export default class VaccinationModel {

    constructor(
        public id?: number,
        public idMember?: number,
        public dateOfReceivingVaccine?: Date,
        public manufacturer?:string
    ) { }
}
