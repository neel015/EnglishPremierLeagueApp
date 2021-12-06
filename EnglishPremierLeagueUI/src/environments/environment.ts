// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

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
