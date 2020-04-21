switch (project.Variables["vybor_kategory"].Value)
{
    case "1":
        project.Variables["tovar_category"].Value = "100";
        break;
     
    case "2":
        project.Variables["tovar_category"].Value = "200";
        break;
     
    default:
        project.Variables["tovar_category"].Value = "300";
        break;
}
