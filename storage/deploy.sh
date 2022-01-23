#! /bin/bash

function step() {
  echo "--------------------------### $1 ###--------------------------"
}

step "Source .env" &&
export $(grep -v '^#' .env | xargs) &&

echo $SUBSCRIPTION &&
echo $RESOURCE_GROUP &&
echo $LOCATION &&
echo $STORAGE_ACCOUNT_NAME &&
echo $CONTAINER &&

step "Set account subscription" &&
az account set --subscription $SUBSCRIPTION &&
az account show
step "Create resource group" &&
az group create \
    --name $RESOURCE_GROUP \
    --location $LOCATION \
    --subscription $SUBSCRIPTION &&

step "Create storage account" &&
az storage account create \
    --name $STORAGE_ACCOUNT_NAME \
    --resource-group $RESOURCE_GROUP \
    --location $LOCATION\
    --sku Standard_LRS \
    --encryption-services blob &&

# Creating the storage container fails
# step "Use signed in user" &&
# az ad signed-in-user show --query objectId -o tsv | az role assignment create \
#     --role "Storage Blob Data Contributor" \
#     --assignee @- \
#     --scope "/subscriptions/$SUBSCRIPTION/resourceGroups/$RESOURCE_GROUP/providers/Microsoft.Storage/storageAccounts/$STORAGE_ACCOUNT_NAME" &&

# step "Create storage container" &&
# az storage container create \
#     --account-name $STORAGE_ACCOUNT_NAME \
#     --name $CONTAINER \
#     --auth-mode login
