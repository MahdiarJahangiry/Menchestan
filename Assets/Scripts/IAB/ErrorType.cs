namespace Menchestan
{
    namespace IAB
    {
        public enum ErrorType
        {
            ERROR_WRONG_SETTINGS = 1,
            ERROR_BAZAAR_NOT_INSTALLED = 2,
            ERROR_SERVICE_NOT_INITIALIZED = 3,
            ERROR_INTERNAL = 4,
            ERROR_OPERATION_CANCELLED = 5,
            ERROR_CONSUME_PURCHASE = 6,
            ERROR_NOT_LOGGED_IN = 7,
            ERROR_HAS_NOT_PRODUCT_IN_INVENTORY = 8,
            ERROR_CONNECTING_VALIDATE_API = 9,
            ERROR_PURCHASE_IS_REFUNDED = 10,
            ERROR_NOT_SUPPORTED_IN_EDITOR = 11,
            ERROR_WRONG_PRODUCT_INDEX = 12,
            ERROR_WRONG_PRODUCT_ID = 13,
            SERVICE_IS_NOW_READY_RETRY_OPERATION = 14,
        }
    }
}