
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace SampleStripeApp.Controllers;

[Route("create-checkout-session")]
[ApiController]
public class CheckoutApiController : ControllerBase
{

  private readonly SessionService _sessionService;

  public CheckoutApiController(SessionService sessionService)
  {
    _sessionService = sessionService;
  }

  [HttpPost]
  public async Task<IActionResult> Create()
  {

    string domain = "https://localhost:5001";

    var options = new SessionCreateOptions
    {
      SuccessUrl = $"{domain}/success.html",
      CancelUrl = $"{domain}/cancel.html",
      LineItems = new List<SessionLineItemOptions>
      {
        new SessionLineItemOptions
        {
          Price = "price_1LCRdeCDTvafG9qIuK45Mfg3",
          Quantity = 1,
        },
      },
      Mode = "payment",
    };

    var session = await _sessionService.CreateAsync(options);

    return Redirect(session.Url);
  }

}