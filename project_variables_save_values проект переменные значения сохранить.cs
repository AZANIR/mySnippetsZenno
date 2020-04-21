//http://zennolab.com/discussion/threads/poluchit-znachenija-vsex-peremennyx.21128/#post-139734

return string.Join("\r\n", project.Variables.Select(v=>v.Key+"="+v.Value.Value)); 