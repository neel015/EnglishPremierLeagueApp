export const environment = {
  production: false,
  apiBaseUrl: "https://localhost:44315",
  apiV1Prefix: "/api/v1",
  msalConfig: {
    clientId: "",
    authority: "https://login.microsoftonline.com/common",
    redirectUrl: "http://localhost:4200",
    postlogoutRedirectUrl: "http://localhost:4200",
    apiScope: ""
  }
};
