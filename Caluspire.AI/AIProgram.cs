using Caluspire.AI.Models;
using Caluspire.AI.Data;
using Caluspire.AI.Services;
using Caluspire.AI.Helpers;

class AIProgram
{
    static void Main(string[] args)
    {
        // training the model
        var trainingData = new List<JobData>
        {
            new JobData { YearsOfExperience = 5, DesiredSalary = 50000, OfferedSalary = 48000, JobType = "CDI" },
            new JobData { YearsOfExperience = 3, DesiredSalary = 45000, OfferedSalary = 46000, JobType = "Freelance" },
            new JobData { YearsOfExperience = 7, DesiredSalary = 55000, OfferedSalary = 53000, JobType = "CDI" },
            new JobData { YearsOfExperience = 2, DesiredSalary = 40000, OfferedSalary = 39000, JobType = "Freelance" },
            new JobData { YearsOfExperience = 10, DesiredSalary = 60000, OfferedSalary = 58000, JobType = "CDI" }
        };

        var modelService = new MLModelService();

        Console.WriteLine("Training the model...");
        modelService.TrainModel(trainingData);
        Console.WriteLine("Model trained successfully!");

        var modelPath = "model.zip";
        ModelHelper.SaveModel(modelService, modelPath);
        Console.WriteLine($"Model saved to file: {modelPath}");

        Console.WriteLine("Loading the model...");
        ModelHelper.LoadModel(modelService, modelPath);
        Console.WriteLine("Model loaded successfully!");

        var newJobData = new InputData
        {
            YearsOfExperience = 4,
            DesiredSalary = 47000,
            OfferedSalary = 46000,
            JobType = "CDI"
        };

        Console.WriteLine("Making prediction...");
        var prediction = modelService.Predict(newJobData);
        Console.WriteLine($"Predicted compatibility score: {prediction}");
    }
}


