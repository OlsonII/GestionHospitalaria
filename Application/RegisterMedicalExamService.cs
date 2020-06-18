using System;
using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class RegisterMedicalExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterMedicalExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegisterMedicalExamResponse Ejecute(RegisterMedicalExamRequest request)
        {
            var turn = CalculateTurn(request);
            
            if(!ValidatePatient(request.Patient))
                return new RegisterMedicalExamResponse {Mensaje = "Este paciente ya tiene el maximo permitido de examenes programados"};
            
            MedicalExam newExam = null;
            var exam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(e => e.Id == request.Identification);
            if (exam == null)
            {
                newExam = new MedicalExam();
                newExam.Name = request.Name;
                newExam.Patient = /*new SearchPatientService(_unitOfWork)
                    .Ejecute(new SearchPatientRequest{Identification = request.Patient.Id}).Patient; //*/
                    request.Patient;
                newExam.Date = request.Date;
                newExam.Turn = turn;
                newExam.Time = "Mañana";
                newExam.State = "Programado";
                newExam.GenerateCost();
                _unitOfWork.MedicalExamRepository.Add(newExam);
                _unitOfWork.Commit();
                return new RegisterMedicalExamResponse {Mensaje = "Examen medico creado satisfactoriamente"};
            }
            
            

            return new RegisterMedicalExamResponse {Mensaje = "Error al registrar el examen medico"};
        }
        
        public bool ValidatePatient(Patient patient)
        {
            var examByPatient = _unitOfWork.MedicalExamRepository.FindBy(m => m.Patient == patient);
            int count = 0;

            foreach (var m in examByPatient)
            {
                if (m.State.Equals("Programado"))
                    count++;

                if (count >= 3)
                    return false;
            }
            
            return true;
        }
        
        private int CalculateTurn(RegisterMedicalExamRequest request)
        {
            var turn = 0;
            var medicalExams = 
                _unitOfWork.MedicalExamRepository.FindBy(m => m.Date == request.Date && m.Patient == request.Patient);
            
            foreach (var appointment in medicalExams)
            {
                if(appointment.State.Equals("Asignado") || appointment.State.Equals("Aplazado"))
                    turn++;
            }

            if (turn == 0)
            {
                return 1;
            }
                

            return turn+1;
        }
    }

    public class RegisterMedicalExamRequest
    {
        public int Identification { get; set; }
        public string Name { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }

    public class RegisterMedicalExamResponse
    {
        public string Mensaje { get; set; }
    }
}