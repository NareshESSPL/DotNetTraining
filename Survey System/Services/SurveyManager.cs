using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Survey_System.Models;
using Survey_System.DTO;
using Survey_System.Interfaces;
using Survey_System.AbstractClasses;

namespace Survey_System.Services
{
 
    public delegate void LogHandler(string message);

    public class SurveyManager : SurveyBase, ISurvey
    {
        private readonly SurveyContext _context;
        public event LogHandler OnLog;

        public SurveyManager(SurveyContext context)
        {
            _context = context;
        }

        private void Log(string message) => OnLog?.Invoke(message);

        // ✅ Implementing ISurvey Methods Correctly

        public async Task<int> AddSurvey(SurveyDTO surveyDto)
        {
            if (string.IsNullOrWhiteSpace(surveyDto.SurveyTypeName))
                throw new ArgumentException("Survey Name cannot be empty.");

            var survey = new Survey
            {
                SurveyTypeID = surveyDto.SurveyTypeID,
                SurveyTypeName = surveyDto.SurveyTypeName,
                ModifiedBy = surveyDto.ModifiedBy,
               
            };

            try
            {
                await _context.Surveys.AddAsync(survey);
                await _context.SaveChangesAsync();
                Log("Survey added successfully.");
                return survey.SurveyID; 
            }
            catch (Exception ex)
            {
                Log($"Error adding survey: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateSurvey(SurveyDTO surveyDto)
        {
            if (string.IsNullOrWhiteSpace(surveyDto.SurveyTypeName))
                throw new ArgumentException("Survey Name cannot be empty.");

            var existingSurvey = await _context.Surveys.FindAsync(surveyDto.SurveyID);
            if (existingSurvey == null)
                throw new KeyNotFoundException("Survey not found.");

            existingSurvey.SurveyTypeID = surveyDto.SurveyTypeID;
            existingSurvey.SurveyTypeName = surveyDto.SurveyTypeName;
            existingSurvey.ModifiedBy = surveyDto.ModifiedBy;
           

            try
            {
                _context.Surveys.Update(existingSurvey);
                await _context.SaveChangesAsync();
                Log("Survey updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Log($"Error updating survey: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteSurvey(int surveyId)
        {
            var survey = await _context.Surveys.FindAsync(surveyId);
            if (survey == null)
                throw new KeyNotFoundException("Survey not found.");

            try
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
                Log("Survey deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Log($"Error deleting survey: {ex.Message}");
                throw;
            }
        }

        public async Task<SurveyDTO> GetSurveyById(int surveyId)
        {
            var survey = await _context.Surveys.FindAsync(surveyId);
            if (survey == null)
                throw new KeyNotFoundException("Survey not found.");

            return new SurveyDTO
            {
                SurveyID = survey.SurveyID,
                SurveyTypeID = survey.SurveyTypeID,
                SurveyTypeName = survey.SurveyTypeName,
                ModifiedBy = survey.ModifiedBy,
               
            };
        }

        public async Task<List<SurveyDTO>> GetAllSurveys()
        {
            return await _context.Surveys
                .Select(s => new SurveyDTO
                {
                    SurveyID = s.SurveyID,
                    SurveyTypeID = s.SurveyTypeID,
                    SurveyTypeName = s.SurveyTypeName,
                    ModifiedBy = s.ModifiedBy,
                   
                })
                .ToListAsync();
        }
    }
}