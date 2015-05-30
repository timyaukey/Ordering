All ID columns that are nullable must be manually modified
in OrderingDataSet.xsd if the typed DataTable containing them
is recreated. These fields must have their "NullValue" property set to "0".

This includes all the ContactId columns in the Vendor table.