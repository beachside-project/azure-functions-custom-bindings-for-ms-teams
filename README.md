# azure functions custom bindings sample

This is MS Teams notification custom bindings sample.

When Http trigger function app get request, functions app send message to MS Teams.

## Prerequisits

### Teams settings

- add **Incoming Webhook** and get webhook url.  
  https://docs.microsoft.com/ja-jp/microsoftteams/platform/concepts/connectors/connectors-using?redirectedfrom=MSDN#setting-up-a-custom-incoming-webhook

  more detail: [my blog post](https://blog.beachside.dev/entry/2019/10/02/212000)

### Functions App settings

Functions App use environment valiable "TeamsWebhookUri", so need to set it.

For local debug, 

- add `local.settings.json` file.
- add following json

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "TeamsWebhookUri": "<teams webhook url !!!! >"
  }
}
```

for Running on Azure,

- Set "TeamsWebhookUri" key and value to Application settings.


## For more information

- [my blog post](https://blog.beachside.dev/entry/2019/10/02/212000).
