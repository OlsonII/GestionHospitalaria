using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class RegisterPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterPatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegisterPatientResponse Ejecute(RegisterPatientRequest request)
        {
            Patient newPatient = null;
            Patient patient =
                _unitOfWork.PatientRepository.FindFirstOrDefault(p =>
                    p.Identification == request.Identification);
            if (patient == null)
            {
                newPatient = new Patient();
                newPatient.Identification = request.Identification;
                newPatient.Name = request.Name;
                newPatient.Surname = request.Surname;
                newPatient.Age = request.Age;
                newPatient.Gender = request.Gender;
                newPatient.Stratum = request.Stratum;
                newPatient.EPS = request.EPS;
                newPatient.GenerateDiscount();
                _unitOfWork.PatientRepository.Add(newPatient);
                _unitOfWork.Commit();
                return new RegisterPatientResponse(){Mensaje = "Paciente registrado satisfactoriamente"};
            }
            else
            {
                return new RegisterPatientResponse(){Mensaje = "Error al registrar el paciente"};
            }
        }
    }
    
    public class RegisterPatientRequest
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string EPS { get; set; }
        public int Stratum { get; set; }
    }

    public class RegisterPatientResponse
    {
        public string Mensaje { get; set; }
    }
}