using Caluspire.AI.Models;
using Caluspire.AI.Data;
using Caluspire.AI.Services;
using Caluspire.AI.Helpers;

class AIProgram
{
    static void Main(string[] args)
    {
        var modelPath = "model.zip";
        var modelService = new MLModelService();

        // Option 1: Train the model from in-memory data (for testing)
        var trainingData = new List<JobData>
        {
            new JobData { YearsOfExperience = 5, DesiredSalary = 50000, OfferedSalary = 48000, JobType = "CDI" },
            new JobData { YearsOfExperience = 3, DesiredSalary = 45000, OfferedSalary = 46000, JobType = "Freelance" },
            new JobData { YearsOfExperience = 7, DesiredSalary = 55000, OfferedSalary = 53000, JobType = "CDI" },
            new JobData { YearsOfExperience = 2, DesiredSalary = 40000, OfferedSalary = 39000, JobType = "Freelance" },
            new JobData { YearsOfExperience = 10, DesiredSalary = 60000, OfferedSalary = 58000, JobType = "CDI" }
        };

        Console.WriteLine("Training the model using in-memory data...");
        modelService.TrainModel(trainingData);
        ModelHelper.SaveModel(modelService, modelPath);
        Console.WriteLine($"Model trained and saved to: {modelPath}");

        Console.WriteLine("Retraining model from CSV file...");
        modelService.TrainFromFile("Data/JobData.csv");
        ModelHelper.SaveModel(modelService, modelPath);
        Console.WriteLine("Model retrained from CSV and saved successfully!");

        ModelHelper.LoadModel(modelService, modelPath);

        var newJobData = new InputData
        {
            YearsOfExperience = 4,
            DesiredSalary = 47000,
            OfferedSalary = 46000,
            JobType = "CDI"
        };

        var prediction = modelService.Predict(newJobData);
        Console.WriteLine($"Predicted compatibility score: {prediction}");
    }
}