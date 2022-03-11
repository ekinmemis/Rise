﻿namespace Rise.EventBus.Events.Basket.Checkout
{
    /// <summary>
    /// Defines the <see cref="CheckoutEvent" />.
    /// </summary>
    public partial class CheckoutEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the CustomerId.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the TotalPrice.
        /// </summary>
        public decimal TotalPrice { get; set; }

        // BillingAddress
        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the AddressLine.
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the ZipCode.
        /// </summary>
        public string ZipCode { get; set; }

        // Payment
        /// <summary>
        /// Gets or sets the CardName.
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// Gets or sets the CardNumber.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the Expiration.
        /// </summary>
        public string Expiration { get; set; }

        /// <summary>
        /// Gets or sets the CVV.
        /// </summary>
        public string CVV { get; set; }

        /// <summary>
        /// Gets or sets the PaymentMethod.
        /// </summary>
        public int PaymentMethod { get; set; }
    }
}
