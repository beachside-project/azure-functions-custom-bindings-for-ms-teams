# azure functions custom bindings sample

This is Teams notification custom bindings sample.

## Prerequisits

### Teams settings

- add **Incoming Webhook** and get webhook url.
  https://docs.microsoft.com/ja-jp/microsoftteams/platform/concepts/connectors/connectors-using?redirectedfrom=MSDN#setting-up-a-custom-incoming-webhook

  more detail: [this my blog post]()

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

for Azure

- add Application settings to "TeamsWebhookUri" key and value.


## For more information

- [my blog post]().