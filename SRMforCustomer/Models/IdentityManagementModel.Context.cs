﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRMforCustomer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IdentityManagementEntities : DbContext
    {
        public IdentityManagementEntities()
            : base("name=IdentityManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessLogs> AccessLogs { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<AppsVersions> AppsVersions { get; set; }
        public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual DbSet<aspnet_Paths> aspnet_Paths { get; set; }
        public virtual DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
        public virtual DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public virtual DbSet<aspnet_Profile> aspnet_Profile { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
        public virtual DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
        public virtual DbSet<AssetBrands> AssetBrands { get; set; }
        public virtual DbSet<AssetDepreciations> AssetDepreciations { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<AssetStatuses> AssetStatuses { get; set; }
        public virtual DbSet<AssetTransferDetails> AssetTransferDetails { get; set; }
        public virtual DbSet<AssetTransfers> AssetTransfers { get; set; }
        public virtual DbSet<AssetTypes> AssetTypes { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<CardHistories> CardHistories { get; set; }
        public virtual DbSet<Cards> Cards { get; set; }
        public virtual DbSet<Childrens> Childrens { get; set; }
        public virtual DbSet<CompanyDivisions> CompanyDivisions { get; set; }
        public virtual DbSet<Configs> Configs { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<DateWages> DateWages { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<DocumentComments> DocumentComments { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<EducationLevels> EducationLevels { get; set; }
        public virtual DbSet<Employment> Employment { get; set; }
        public virtual DbSet<EmploymentLogs> EmploymentLogs { get; set; }
        public virtual DbSet<ExtraWorkingDays> ExtraWorkingDays { get; set; }
        public virtual DbSet<Facitilities> Facitilities { get; set; }
        public virtual DbSet<FoodCoupons> FoodCoupons { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Grants> Grants { get; set; }
        public virtual DbSet<Holidays> Holidays { get; set; }
        public virtual DbSet<Incentive> Incentive { get; set; }
        public virtual DbSet<JobDetails> JobDetails { get; set; }
        public virtual DbSet<LeacePrivilegeConfig> LeacePrivilegeConfig { get; set; }
        public virtual DbSet<LeaveApprovals> LeaveApprovals { get; set; }
        public virtual DbSet<LeaveAttachments> LeaveAttachments { get; set; }
        public virtual DbSet<LeaveRequests> LeaveRequests { get; set; }
        public virtual DbSet<LeaveSummary> LeaveSummary { get; set; }
        public virtual DbSet<LetterOfGuarunteeDetails> LetterOfGuarunteeDetails { get; set; }
        public virtual DbSet<LetterOfGuaruntees> LetterOfGuaruntees { get; set; }
        public virtual DbSet<LockerHistories> LockerHistories { get; set; }
        public virtual DbSet<LockerLocations> LockerLocations { get; set; }
        public virtual DbSet<Lockers> Lockers { get; set; }
        public virtual DbSet<Marriages> Marriages { get; set; }
        public virtual DbSet<MasterTypes> MasterTypes { get; set; }
        public virtual DbSet<MeetingDetails> MeetingDetails { get; set; }
        public virtual DbSet<MeetingGroups> MeetingGroups { get; set; }
        public virtual DbSet<MeetingRooms> MeetingRooms { get; set; }
        public virtual DbSet<Meetings> Meetings { get; set; }
        public virtual DbSet<MovementLogs> MovementLogs { get; set; }
        public virtual DbSet<OTApprovals> OTApprovals { get; set; }
        public virtual DbSet<OTRequests> OTRequests { get; set; }
        public virtual DbSet<ParentInfos> ParentInfos { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<PeriodDetails> PeriodDetails { get; set; }
        public virtual DbSet<Periods> Periods { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<ProvidentFundPercentages> ProvidentFundPercentages { get; set; }
        public virtual DbSet<ProvidentFundPlan> ProvidentFundPlan { get; set; }
        public virtual DbSet<ProvidentFundRates> ProvidentFundRates { get; set; }
        public virtual DbSet<ProvidentFunds> ProvidentFunds { get; set; }
        public virtual DbSet<PRPOUserStats> PRPOUserStats { get; set; }
        public virtual DbSet<Ranks> Ranks { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<SsoHospitals> SsoHospitals { get; set; }
        public virtual DbSet<SsoHospitals_BK> SsoHospitals_BK { get; set; }
        public virtual DbSet<SsoNationalitys> SsoNationalitys { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<TimeStamps> TimeStamps { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }
        public virtual DbSet<Trainings> Trainings { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserInGroupMeetings> UserInGroupMeetings { get; set; }
        public virtual DbSet<UserInManualShifts> UserInManualShifts { get; set; }
        public virtual DbSet<UserInPeriods> UserInPeriods { get; set; }
        public virtual DbSet<UserInShifts> UserInShifts { get; set; }
        public virtual DbSet<UserLeaveDays> UserLeaveDays { get; set; }
        public virtual DbSet<UserPrivateInfo> UserPrivateInfo { get; set; }
        public virtual DbSet<WelfareHistories> WelfareHistories { get; set; }
        public virtual DbSet<PasswordRecoveryRequests> PasswordRecoveryRequests { get; set; }
        public virtual DbSet<UserInfoEditHistories> UserInfoEditHistories { get; set; }
        public virtual DbSet<vw_aspnet_Applications> vw_aspnet_Applications { get; set; }
        public virtual DbSet<vw_aspnet_MembershipUsers> vw_aspnet_MembershipUsers { get; set; }
        public virtual DbSet<vw_aspnet_Profiles> vw_aspnet_Profiles { get; set; }
        public virtual DbSet<vw_aspnet_Roles> vw_aspnet_Roles { get; set; }
        public virtual DbSet<vw_aspnet_Users> vw_aspnet_Users { get; set; }
        public virtual DbSet<vw_aspnet_UsersInRoles> vw_aspnet_UsersInRoles { get; set; }
        public virtual DbSet<vw_aspnet_WebPartState_Paths> vw_aspnet_WebPartState_Paths { get; set; }
        public virtual DbSet<vw_aspnet_WebPartState_Shared> vw_aspnet_WebPartState_Shared { get; set; }
        public virtual DbSet<vw_aspnet_WebPartState_User> vw_aspnet_WebPartState_User { get; set; }
        public virtual DbSet<vwAddresses> vwAddresses { get; set; }
        public virtual DbSet<vwAssetChanges> vwAssetChanges { get; set; }
        public virtual DbSet<vwAssetDepreciations> vwAssetDepreciations { get; set; }
        public virtual DbSet<vwAssetItemDetails> vwAssetItemDetails { get; set; }
        public virtual DbSet<vwAssetMaxTransaction> vwAssetMaxTransaction { get; set; }
        public virtual DbSet<vwAssets> vwAssets { get; set; }
        public virtual DbSet<vwAssetTransaction> vwAssetTransaction { get; set; }
        public virtual DbSet<vwAssetTransferDetails> vwAssetTransferDetails { get; set; }
        public virtual DbSet<vwAssetTransfers> vwAssetTransfers { get; set; }
        public virtual DbSet<vwAssetTypes> vwAssetTypes { get; set; }
        public virtual DbSet<vwAssetUserInfo> vwAssetUserInfo { get; set; }
        public virtual DbSet<vwCardHistories> vwCardHistories { get; set; }
        public virtual DbSet<vwCardHistoriesNameEmpOut> vwCardHistoriesNameEmpOut { get; set; }
        public virtual DbSet<vwCardLites> vwCardLites { get; set; }
        public virtual DbSet<vwCards> vwCards { get; set; }
        public virtual DbSet<vwCourses> vwCourses { get; set; }
        public virtual DbSet<vwDataAdmins> vwDataAdmins { get; set; }
        public virtual DbSet<vwDatadict> vwDatadict { get; set; }
        public virtual DbSet<vwDepartment> vwDepartment { get; set; }
        public virtual DbSet<vwDepartmentManager> vwDepartmentManager { get; set; }
        public virtual DbSet<vwDivisionTrees> vwDivisionTrees { get; set; }
        public virtual DbSet<vwDocScanUserInRole> vwDocScanUserInRole { get; set; }
        public virtual DbSet<vwEducations> vwEducations { get; set; }
        public virtual DbSet<vwFFAccountingTeam> vwFFAccountingTeam { get; set; }
        public virtual DbSet<vwFFProcessingTeam> vwFFProcessingTeam { get; set; }
        public virtual DbSet<vwFoodCouponCompany> vwFoodCouponCompany { get; set; }
        public virtual DbSet<vwLeacePrivilegeConfig> vwLeacePrivilegeConfig { get; set; }
        public virtual DbSet<vwLeaveRequests> vwLeaveRequests { get; set; }
        public virtual DbSet<vwLockAndApproveUser> vwLockAndApproveUser { get; set; }
        public virtual DbSet<vwLockerHistories> vwLockerHistories { get; set; }
        public virtual DbSet<vwLockerLites> vwLockerLites { get; set; }
        public virtual DbSet<vwLockers> vwLockers { get; set; }
        public virtual DbSet<vwMarketingPurchasingTeam> vwMarketingPurchasingTeam { get; set; }
        public virtual DbSet<vwOTRequests> vwOTRequests { get; set; }
        public virtual DbSet<vwPRPOUserStats> vwPRPOUserStats { get; set; }
        public virtual DbSet<vwPurchasingTeam> vwPurchasingTeam { get; set; }
        public virtual DbSet<vwRoles> vwRoles { get; set; }
        public virtual DbSet<vwTimeStamps> vwTimeStamps { get; set; }
        public virtual DbSet<vwUserBarcodes> vwUserBarcodes { get; set; }
        public virtual DbSet<vwUserInfo> vwUserInfo { get; set; }
        public virtual DbSet<vwUserInfo2> vwUserInfo2 { get; set; }
        public virtual DbSet<vwUserInfoLite> vwUserInfoLite { get; set; }
        public virtual DbSet<vwUserInfoLite2> vwUserInfoLite2 { get; set; }
        public virtual DbSet<vwUserInfoWithMasterType> vwUserInfoWithMasterType { get; set; }
        public virtual DbSet<vwUserInShift> vwUserInShift { get; set; }
        public virtual DbSet<vwUserLeaveDays> vwUserLeaveDays { get; set; }
        public virtual DbSet<vwUsersInRoles> vwUsersInRoles { get; set; }
    }
}
