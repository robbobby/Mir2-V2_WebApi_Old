# Mir2-V2_WebApi

# Setup

  This is currently using AWS DynamoDb

  For the project to work you must setup a DynamoDb table.

    Set the table name to whatever is preferred
    When setting up the DynamoDb make sure you set the following properties
    
    Partition Key: Id : string
    Sort Key: EntryTypeId : number
  
Next you must also make a IAM user in AWS and give full access rights to DynamoDB for this role.
Download the access key file for the next step.
    
Make a new json file somewhere on your computer that is safe and not in a remote repository and add the json. Insert the values into the JSON file from the IAM user
```json
{
    "DynamoDbAccess": {
        "AccessKey": "ACCESS KEY HERE",
        "SecretKey": "SECRET KEY HERE"
    }
}
```
Next we need to insert the details into the applications config. We need the name of the database you made on AWS.
Also we need the path of the file you have just, put the details into the DevelopmentConfig file inside of the project

### Please note that if you are using windows the path to the file will contain '\\', this may act as a escape character when c# reads it so whenever you see a '\\' in your path please change it to '\\\\'
  
```json
    {
        "database": {
            "name": "DATABASE NAME HERE",
            "awsKeyFile": "/PATH/TO/AMAZON_ACCESS_KEY/GOES_HERE.json"
        }
    }

```
