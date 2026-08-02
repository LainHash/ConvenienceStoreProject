using System.Text.Json.Serialization;

namespace ConvenienceStore.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        DebitCard,
        BankTransfer,
        MoMo,
        ZaloPay,
        VNPay,
        PayPal,
        COD
    }
}
