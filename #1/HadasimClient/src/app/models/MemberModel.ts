import CovidDetailsModel from "./CovidDetailsModel";
import VaccinationModel from "./VaccinationModel";

export default class MemberModel {

    constructor(
        public idMember?: number,
        public firstName?: string,
        public lastName?: string,
        public tz?: number,
        public city?: string,
        public street?: string,
        public numBuilding?: number,
        public dateOfBitrth?: Date,
        public phone?: string,
        public mobilePhone?: string,
        public covidDetails?: CovidDetailsModel,
        public vaccinations: VaccinationModel[]=[]
    ) { }
}

		