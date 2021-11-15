namespace CGInnovation.ProjectZen.Permissions
{
    public static class ProjectZenPermissions
    {
        public const string GroupName = "ProjectZen";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public static class Risks
        {
            public const string Default = GroupName + ".Risks";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}


