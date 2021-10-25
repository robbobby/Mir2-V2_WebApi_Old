# Mir2-V2_WebApi

# Setup

This is currently using AWS DynamoDb

Foir the files to work you must setup a DynamoDb table
  Place the name of the table in the DevelopmentConfig.json under 
    ```json
    "database": {
    "name": "DATABASE NAME HERE",```
    
    
    You must also make a IAM user in AWS and give full access rights to DynamoDB for this role.
    
    Make a new json file somewhere on your computer that is safe and not in a remote repository and add the json 
    ```{
  "DynamoDbAccess": {
    "AccessKey": "",
    "SecretKey": ""
  }
}```
