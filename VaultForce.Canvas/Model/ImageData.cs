using VaultForce.Canvas.Infrastructure;
using System.Text.Json.Serialization;

namespace VaultForce.Canvas.Model;

public class ImageData
{
    [JsonPropertyName("data")]
    [JsonConverter(typeof(ImageDataArrayConverter))]
    public byte[] Data { get; set; } = [];
}