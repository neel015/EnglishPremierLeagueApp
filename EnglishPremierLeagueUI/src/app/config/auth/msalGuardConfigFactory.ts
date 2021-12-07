import { MsalGuardConfiguration } from "@azure/msal-angular";
import { InteractionType } from "@azure/msal-browser";
import { environment } from "src/environments/environment";

export function MSALGuardConfigFactory(): MsalGuardConfiguration {
    return { 
      interactionType: InteractionType.Redirect,
      authRequest: {
        scopes: ['user.read', environment.msalConfig.apiScope]
      },
      loginFailedRoute: '/no-access'
    };
}