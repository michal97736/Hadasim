export default class CovidDetailsModel {

    constructor(
        public id?: number,
        public idMember?: number,
        public dateOfPositiveResult?: Date,
        public dateOfRecovery?:Date
    ) { }
}

