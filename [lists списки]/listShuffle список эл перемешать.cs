Random RND = new Random();
for (int i = 0; i < project.Lists["Rand_keywords"].Count; i++)
{
	string tmp = project.Lists["Rand_keywords"][0];
	project.Lists["Rand_keywords"].RemoveAt(0);
	project.Lists["Rand_keywords"].Insert(RND.Next(project.Lists["Rand_keywords"].Count), tmp);
}