using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class RegisterDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterDoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegisterDoctorResponse Ejecute(RegisterDoctorRequest request)
        {
            Doctor newDoctor = null;
            var doctor =
                _unitOfWork.DoctorRepository.FindFirstOrDefault(d =>
                    d.Id == request.Identification);
            
            if(ValidateExperience(request.Experience))
                return new RegisterDoctorResponse {Mensaje = "Experiencia no permitida para el registro del doctor"};
            
            if (doctor == null)
            {
                newDoctor = new Doctor();
                newDoctor.Id = request.Identification;
                newDoctor.Name = request.Name;
                newDoctor.Surname = request.Surname;
                newDoctor.Age = request.Age;
                newDoctor.Gender = request.Gender;
                newDoctor.Degree = request.Degree;
                newDoctor.Experience = request.Experience;
                newDoctor.Workday = request.Workday;
                _unitOfWork.DoctorRepository.Add(newDoctor);
                _unitOfWork.Commit();
                return new RegisterDoctorResponse {Mensaje = "Doctor registrado satisfactoriamente"};
            }

            return new RegisterDoctorResponse {Mensaje = "El doctor que intenta registrar ya existe"};
        }

        private bool ValidateExperience(int experience)
        {
            if (experience < 24)
                return false;
            
            return true;
        }
    }

    public class RegisterDoctorRequest
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Experience { get; set; }
        public string Workday { get; set; }
        public string Degree { get; set; }
    }

    public class RegisterDoctorResponse
    {
        public string Mensaje { get; set; }
    }
}