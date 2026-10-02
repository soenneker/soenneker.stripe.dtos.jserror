using System.Text.Json;
using System.Text.Json.Serialization;

namespace Soenneker.Stripe.Dtos.JsError;

/// <summary>
/// An error returned by Stripe.js. Error codes remain strings so new Stripe values can be received without rejecting the result.
/// </summary>
public sealed class StripeJsError
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("decline_code")]
    public string? DeclineCode { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("param")]
    public string? Param { get; set; }

    [JsonPropertyName("doc_url")]
    public string? DocumentationUrl { get; set; }

    [JsonPropertyName("request_log_url")]
    public string? RequestLogUrl { get; set; }

    [JsonPropertyName("charge")]
    public string? Charge { get; set; }

    /// <summary>The PaymentIntent object supplied with the error, when present.</summary>
    [JsonPropertyName("payment_intent")]
    public JsonElement? PaymentIntent { get; set; }

    /// <summary>The SetupIntent object supplied with the error, when present.</summary>
    [JsonPropertyName("setup_intent")]
    public JsonElement? SetupIntent { get; set; }

    /// <summary>The PaymentMethod object supplied with the error, when present.</summary>
    [JsonPropertyName("payment_method")]
    public JsonElement? PaymentMethod { get; set; }

    /// <summary>The Source object supplied with the error, when present.</summary>
    [JsonPropertyName("source")]
    public JsonElement? Source { get; set; }
}
