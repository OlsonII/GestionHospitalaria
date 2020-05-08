using System;
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
            Doctor doctor =
                _unitOfWork.DoctorRepository.FindFirstOrDefault(d =>
                    d.Identification == request.Identification);
            if (doctor == null)
            {
                newDoctor = new Doctor();
                newDoctor.Name = request.Name;
                newDoctor.Surname = request.Surname;
                newDoctor.Age = request.Age;
                newDoctor.Gender = request.Gender;
                newDoctor.Degree = request.Degree;
                newDoctor.Experience = request.Experience;
                newDoctor.GenerateWorkDay();
                _unitOfWork.DoctorRepository.Add(newDoctor);
                _unitOfWork.Commit();
                return new RegisterDoctorResponse(){Mensaje = "Doctor registrado satisfactoriamente"};
            }
            else
            {
                return new RegisterDoctorResponse(){Mensaje = "Error al registrar el doctor"};
            }
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
        public string Degree { get; set; }
    }

    public class RegisterDoctorResponse
    {
        public string Mensaje { get; set; }
    }
}