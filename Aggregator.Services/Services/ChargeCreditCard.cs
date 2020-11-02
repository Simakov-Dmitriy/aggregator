using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using Aggregator.Services.ModelsDto;
using Aggregator.Services;
using Aggregator.Domain.Models;

namespace Aggregator.Services
{
    public class ChargeCreditCard
    {
        private readonly UserInfoService _userInfoService;
        public ChargeCreditCard()
        {
            _userInfoService = new UserInfoService();
        }

        public Transaction Run( BuyTicketsDto buyTicket, Сustomer сustomer)
        {

            string apiLoginId = Configuration.AppConfiguration.ApiLoginId;
            string transactionKey = Configuration.AppConfiguration.ApiTransactionKey;

            //const string apiLoginId = "5KP3u95bQpv";
            //const string transactionKey = "346HZ32z3fP4hTG2";

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = transactionKey,
            };

            var creditCard = new creditCardType
            {
                cardNumber = buyTicket.Card.CardNumber,
                expirationDate = buyTicket.Card.ExpirationDate,
                cardCode = buyTicket.Card.CVV,
            };

 


            //standard api call to retrieve response
            var paymentType = new paymentType { Item = creditCard };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = buyTicket.Amount,
                payment = paymentType
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            // instantiate the controller that will call the service
            var controller = new createTransactionController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();


            var transaction = new Transaction();
            transaction.CustomerId = сustomer.Id;
            // validate response
            bool result = false;
            
            if( response != null )
            {
                if( response.messages.resultCode == messageTypeEnum.Ok )
                {
                    if( response.transactionResponse.messages != null )
                    {
                        transaction.TransactionId = response.transactionResponse.transId;
                        transaction.ResponseCode = response.transactionResponse.responseCode;
                        transaction.MessageCode = response.transactionResponse.messages[ 0 ].code;
                        transaction.Description = response.transactionResponse.messages[ 0 ].description;
                        transaction.HashCode = response.transactionResponse.transHash;
                        transaction.AuthCode = response.transactionResponse.authCode;
                        result = true;
                    }
                    else
                    {
                        Console.WriteLine("Failed Transaction.");
                        if( response.transactionResponse.errors != null )
                        {
                            transaction.ErrorCode = response.transactionResponse.errors[ 0 ].errorCode;
                            transaction.ErrorMessage = response.transactionResponse.errors[ 0 ].errorText;
                        }
                    }
                }
                else
                {
                    //Failed Transaction
                    if( response.transactionResponse != null && response.transactionResponse.errors != null )
                    {
                        transaction.ErrorCode = response.transactionResponse.errors[ 0 ].errorCode;
                        transaction.ErrorMessage = response.transactionResponse.errors[ 0 ].errorText;
                    }
                    else
                    {
                        transaction.ErrorCode = response.messages.message[ 0 ].code;
                        transaction.ErrorMessage = response.messages.message[ 0 ].text;
                    }
                }
            }
            else
            {
                // Display the error code and message when response is null
                ANetApiResponse errorResponse = controller.GetErrorResponse();
                //Failed to get response
                if( !string.IsNullOrEmpty(errorResponse.messages.message.ToString()) )
                {
                    transaction.ErrorCode = errorResponse.messages.message[ 0 ].code;
                    transaction.ErrorMessage = errorResponse.messages.message[ 0 ].text;
                }
            }
            return transaction;
        }
    }
}
