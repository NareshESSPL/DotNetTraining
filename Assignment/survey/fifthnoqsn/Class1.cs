using System;

namespace fifthnoqsn
{
     
    public interface ISurvey
    {
        void CreateSurvey(string name);
        string ReadSurvey(int id);
        void UpdateSurvey(int id, string name);
        void DeleteSurvey(int id);
    }

    public class Class1 : ISurvey
    {
        

        public void CreateSurvey(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Survey name cannot be empty.", nameof(name));
            }
            //logic to carete the survey
        
            if (name.Length < 3)
            {
                throw new ArgumentException("Survey name must be at least 3 characters long.", nameof(name));
            }
            if (name.Length > 100)
            {
                throw new ArgumentException("Survey name must not exceed 100 characters.", nameof(name));
            }
            if (!char.IsUpper(name[0]))
            {
                throw new ArgumentException("Survey name must start with an uppercase letter.", nameof(name));
            }
            if (name.Contains(" "))
            {
                throw new ArgumentException("Survey name must not contain spaces.", nameof(name));
            }

            Console.WriteLine($"Survey '{name}' created.");
        }

        public string ReadSurvey(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Survey ID must be a positive integer.", nameof(id));
            }

            return $"Survey with ID {id} read.";
        }

        public void UpdateSurvey(int id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Survey ID must be a positive integer.", nameof(id));
            }

            Console.WriteLine($"Survey with ID {id} updated to '{name}'.");
        }

        public void DeleteSurvey(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Survey ID must be a positive integer.", nameof(id));
            }

            Console.WriteLine($"Survey with ID {id} deleted.");
        }
    }
}
