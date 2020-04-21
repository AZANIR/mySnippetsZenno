DateTime date_start = Convert.ToDateTime(project.Variables["m_time_start"].Value);
DateTime date_site = Convert.ToDateTime(project.Variables["m_time_site"].Value);
 
 
if(date_start < date_site){
    return "true"; //выход по зелёной
}else{
    throw new Exception("false"); //по красной
}