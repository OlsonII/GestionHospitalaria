﻿using System;
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
            MedicalExam newExam = null;
            MedicalExam exam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(e => e.Code == request.Code);
            if (exam == null)
            {
                newExam = new MedicalExam();
                newExam.Code = request.Code;
                newExam.Name = request.Name;
                newExam.Patient = request.Patient;
                newExam.Date = request.Date;
                newExam.Hour = request.Hour;
                newExam.State = "Programado";
                newExam.GenerateCost();
                _unitOfWork.MedicalExamRepository.Add(newExam);
                _unitOfWork.Commit();
                return new RegisterMedicalExamResponse() {Mensaje = "Examen medico creado satisfactoriamente"};
            }
            else
            {
                return new RegisterMedicalExamResponse() {Mensaje = "Error al registrar el examen medico"};
            }
        }
        
    }
    
    public class RegisterMedicalExamRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Patient Patient { get; set; }
        public DateTime Hour { get; set; }
        public DateTime Date { get; set; }
    }
    
    public class RegisterMedicalExamResponse
    {
        public string Mensaje { get; set; }
    }
}