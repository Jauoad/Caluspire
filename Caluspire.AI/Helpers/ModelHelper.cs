using Caluspire.AI.Services;

namespace Caluspire.AI.Helpers
{
    public static class ModelHelper
    {
        public static void SaveModel(MLModelService modelService, string modelPath)
        {
            if (modelService == null || modelService.Model == null)
                throw new ArgumentNullException(nameof(modelService), "Model is not trained.");

            using (var fs = new FileStream(modelPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                modelService.MLContext.Model.Save(modelService.Model, inputSchema: null, stream: fs);
            }
        }

        public static void LoadModel(MLModelService modelService, string modelPath)
        {
            if (modelService == null)
                throw new ArgumentNullException(nameof(modelService));

            if (File.Exists(modelPath))
            {
                using (var fs = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    modelService.Model = modelService.MLContext.Model.Load(fs, out var _);
                }
            }
            else
            {
                throw new FileNotFoundException("Model file not found.", modelPath);
            }
        }
    }
}
