namespace Shoghlana.Api.Response
{
    public class GeneralResponse
    {
        public bool IsSuccess { get; set; }

        /// <summary>
        /// made it dynamic not generic so that if was case has to return differnt types in the same controller based on some condition
        /// u can use it to send failer message if failed.. or to send the DTO if success or to send the object itself when added or edited
        /// </summary>
        public dynamic? Data { get; set; }

        /// <summary>
        /// use it if u want to add any notes to the consumer in case success with notes or add or edit or delete
        /// </summary>
        public string? Message { get; set; } = string.Empty;

        /// <summary>
        /// In case of failer the consumer can easily know the reason by checking on the common failer satus codes(404 , 500 ... etc) => and make handler for each one
        /// It's way better than checking the string message to know the failer reason 
        /// </summary>
        public int Status { get; set; }

        public string? Token { get; set; } =   null;

        public DateTime? Expired { get; set; } = null;
    }
}