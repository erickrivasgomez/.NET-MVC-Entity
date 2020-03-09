using Newtonsoft.Json;

namespace Training.DTO
{
    public class OrderProduct
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }
}
