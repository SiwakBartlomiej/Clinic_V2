export default interface Appointment {
  date: Date
  medicalPersonnel: MedicalPersonnel
  type: string
  reason?: string
  diagnosis?: boolean
}

enum MedicalPersonnelType {
  Doctor,
  Nurse,
}

interface MedicalPersonnel {
  id: number
  title: string
  firstName: string
  lastName: string
  specialization: string
  personelType: MedicalPersonnelType
}
