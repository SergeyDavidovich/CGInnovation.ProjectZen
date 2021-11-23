namespace CGInnovation.ProjectZen.Permissions
{
    public static class ProjectZenPermissions
    {
        public const string GroupName = "ProjectZen";
        public static class Risks
        {
            public const string Default = GroupName + ".Risks";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class Projects
        {
            public const string Default = GroupName + ".Projects";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class Strategies
        {
            public const string Default = GroupName + ".Strategies";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}


