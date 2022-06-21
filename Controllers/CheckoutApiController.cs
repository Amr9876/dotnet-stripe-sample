
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace SampleStripeApp.Controllers;

[Route("create-checkout-session")]
[ApiController]
public class CheckoutApiController : ControllerBase
{

  private readonly SessionService _sessionService;
  
  private readonly IConfiguration _config;

  public CheckoutApiController(SessionService sessionService, IConfiguration config)
  {
    _sessionService = sessionService;
    _config = config;
  }

  [HttpPost]
  public async Task<IActionResult> Create()
  {

    string domain = "https://dotnet-stripe-sample.herokuapp.com";

    var options = new SessionCreateOptions
    {
      SuccessUrl = $"{domain}/success.html",
      CancelUrl = $"{domain}/cancel.html",
      LineItems = new List<SessionLineItemOptions>
      {
        new SessionLineItemOptions
        {
          Price = _config["StripeProductPrice"],
          Quantity = 1,
        },
      },
      Mode = "payment",
    };

    var session = await _sessionService.CreateAsync(options);

    return Redirect(session.Url);
  }

}
