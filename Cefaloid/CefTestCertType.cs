namespace Cefaloid;

public enum CefTestCertType : int { // cef_test_cert_type_t
  CefTestCertOkIp = 0, // CEF_TEST_CERT_OK_IP
  CefTestCertOkDomain = 1, // CEF_TEST_CERT_OK_DOMAIN
  CefTestCertExpired = 2, // CEF_TEST_CERT_EXPIRED
}