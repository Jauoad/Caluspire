using Microsoft.ML;
using Microsoft.ML.Data;
using Caluspire.AI.Models;
using Caluspire.AI.Data;
using System.Collections.Generic;

namespace Caluspire.AI.Services
{
    public class MLModelService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public MLModelService()
        {
            _mlContext = new MLContext();
        }

        public MLContext MLContext => _mlContext;
        public ITransformer Model
        {
            get => _model;
            set => _model = value;
        }

        public void TrainModel(IEnumerable<JobData> trainingData)
        {
            var data = _mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = _mlContext.Transforms.Concatenate("Features", new[] { "YearsOfExperience", "DesiredSalary", "OfferedSalary" })
                .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: "CompatibilityScore"));

            _model = pipeline.Fit(data);
        }

        public float Predict(InputData inputData)
        {
            var predictionFunction = _mlContext.Model.CreatePredictionEngine<InputData, Prediction>(_model);
            var prediction = predictionFunction.Predict(inputData);
            return prediction.CompatibilityScore;
        }
    }
}
