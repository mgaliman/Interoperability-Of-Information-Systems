namespace IIS_07_UI.Models
{
    public class FreeNewsAPIModel
    {
        public FreeNewsAPIModel()
        {

        }

        public FreeNewsAPIModel(string query, string language)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
