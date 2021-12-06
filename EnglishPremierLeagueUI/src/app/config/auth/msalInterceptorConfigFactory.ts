import { MsalInterceptorConfiguration } from "@azure/msal-angular";
import { InteractionType } from "@azure/msal-browser";
import { environment } from "src/environments/environment";

export function MSALInterceptorConfigFactory(): MsalInterceptorConfiguration {
    const protectedResourceMap = new Map<string, Array<string>>();
    protectedResourceMap.set(environment.apiBaseUrl, [environment.msalConfig.apiScope])  
    return {
      interactionType: InteractionType.Redirect,
      protectedResourceMap
    };
  }