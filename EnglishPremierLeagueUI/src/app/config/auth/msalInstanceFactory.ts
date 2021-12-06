import { BrowserCacheLocation, IPublicClientApplication, LogLevel, PublicClientApplication } from "@azure/msal-browser";
import { environment } from "src/environments/environment";

export function MSALInstanceFactory(): IPublicClientApplication {
    return new PublicClientApplication({
      auth: {
        clientId: environment.msalConfig.clientId, 
        authority: environment.msalConfig.authority, 
        redirectUri: environment.msalConfig.redirectUrl,
        postLogoutRedirectUri: environment.msalConfig.postlogoutRedirectUrl
      },
      cache: {
        cacheLocation: BrowserCacheLocation.LocalStorage,
        storeAuthStateInCookie: false, 
      },
      system: {
        allowRedirectInIframe: true,
        loggerOptions: {
          loggerCallback,
          logLevel: LogLevel.Info,
          piiLoggingEnabled: false
        }
      }
    });
}

export function loggerCallback(logLevel: LogLevel, message: string) {
  console.log(message);
}
  