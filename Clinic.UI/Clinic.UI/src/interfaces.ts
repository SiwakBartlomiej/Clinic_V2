export interface Appointment {
  id: number
  date: Date
  medicalPersonnel: MedicalPersonnel
  type: string
  reason?: string
  diagnosis?: boolean
}

export enum MedicalPersonnelType {
  Doctor,
  Nurse,
}

export interface MedicalPersonnel {
  id: number
  title: string
  firstName: string
  lastName: string
  specialization: string
  personelType: MedicalPersonnelType
}

export interface ContactInformation {
  address: Address
  phone: string
  email: string
}

export interface Address {
  street: string
  postalCode: string
  city: string
}
