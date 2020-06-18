//Xml ToList example 1 
var list_xml = new List<string>();
for(int i = 0; i < project.Xml.PurchaseOrder.Address.Count; i++)
{
	list_xml.Add(project.Xml.PurchaseOrder.Address[i].Name.Value);
}
//выводим содержимое списка обьединив через ","
return string.Join(", ", list_xml);

//Xml ToList example 2 
var list_xml = new List<string>();
foreach(dynamic i in project.Xml.PurchaseOrder.Address)
{
	list_xml.Add(i.Name.Value);
}
//выводим содержимое списка обьединив через ","
return string.Join(", ", list_xml);


//Json ToList example 1 
var list_json = new List<string>();
for(int i = 0; i < project.Json.PurchaseOrder.Address.Count; i++)
{
	list_json.Add(project.Json.PurchaseOrder.Address[i].Name.Value);
}
//выводим содержимое списка обьединив через ","
return string.Join(", ", list_json);

//Json ToList example 2 
var list_json = new List<string>();
foreach(dynamic i in project.Json.PurchaseOrder.Address)
{
	list_json.Add(i.Name.Value);
}
//выводим содержимое списка обьединив через ","
return string.Join(", ", list_json);