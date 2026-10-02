using System.Text.Json;
using System.Threading.Tasks;

namespace Soenneker.Stripe.Dtos.JsError.Tests;

public sealed class StripeJsErrorTests
{
    [Test]
    [Arguments("validation_error")]
    [Arguments("api_connection_error")]
    [Arguments("future_error")]
    public async Task Browser_error_values_are_preserved(string type)
    {
        string json = $$"""{"type":"{{type}}","code":"future_code","decline_code":"future_decline","message":"Test error"}""";
        StripeJsError error = JsonSerializer.Deserialize<StripeJsError>(json)!;
        await Assert.That(error.Type).IsEqualTo(type);
        await Assert.That(error.Code).IsEqualTo("future_code");
        await Assert.That(error.DeclineCode).IsEqualTo("future_decline");
        await Assert.That(error.Message).IsEqualTo("Test error");
    }

    [Test]
    public async Task Expanded_objects_survive_round_trip()
    {
        const string json = """
            {"type":"card_error","payment_intent":{"id":"pi_test","amount":10000},
            "setup_intent":{"id":"seti_test"},"payment_method":{"id":"pm_test"},"source":{"id":"src_test"}}
            """;
        StripeJsError error = JsonSerializer.Deserialize<StripeJsError>(json)!;
        StripeJsError copy = JsonSerializer.Deserialize<StripeJsError>(JsonSerializer.Serialize(error))!;
        await Assert.That(copy.PaymentIntent!.Value.GetProperty("id").GetString()).IsEqualTo("pi_test");
        await Assert.That(copy.PaymentIntent.Value.GetProperty("amount").GetInt32()).IsEqualTo(10000);
        await Assert.That(copy.SetupIntent!.Value.GetProperty("id").GetString()).IsEqualTo("seti_test");
        await Assert.That(copy.PaymentMethod!.Value.GetProperty("id").GetString()).IsEqualTo("pm_test");
        await Assert.That(copy.Source!.Value.GetProperty("id").GetString()).IsEqualTo("src_test");
    }
}
