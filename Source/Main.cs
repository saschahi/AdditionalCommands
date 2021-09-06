using Verse;
using TorannMagic;
using TorannMagic.TMDefs;
using RimWorld;
using TorannMagic.ModOptions;
using System.Collections.Generic;
using System;
using System.Linq;
using TwitchLib.Client.Models.Interfaces;

namespace AdditionalCommands
{

    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main() //our constructor
        {
            
        }
    }

    public class mypawnmagicskills : CommandBase
    {
        public override void RunCommand(ITwitchMessage twitchMessage)
        {
            Pawn pawn = GetOrFindPawn(twitchMessage.Username, false);
            if (pawn != null)
            {
                //Log.Message("SASCHAHI DEBUG: " + skill);

                string message = "";

                if (pawn.TryGetComp<CompAbilityUserMagic>().IsMagicUser)
                {
                    string magic = FindMagic(pawn);
                    if(magic != "")
                    {
                        message = "Magic Skills: " + magic;
                    }
                }

                if (pawn.TryGetComp<CompAbilityUserMight>().IsMightUser)
                {
                    string might = FindMight(pawn);
                    if (might != "")
                    {
                        if(message != "")
                        {
                            message = message + " - Might Skills: " + might;
                        }
                        else
                        {
                            message = "Might Skills: " + might;
                        }
                    }
                }

                if (message != "")
                {
                    /*
                    if(message.Length >499)
                    {
                        string message1 = (string)message.Take(400);
                        ToolkitCore.TwitchWrapper.SendChatMessage(message1);
                    }
                    */
                    ToolkitCore.TwitchWrapper.SendChatMessage(message);
                }
                else
                {
                    ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " We couldn't find any skills you can currently level");
                }
            }
            else
            {
                Log.Message("Saschahi: No Connected pawn found");
            }
        }

        public string FindMagic(Pawn pawn)
        {
            string skills = "";

            CompAbilityUserMagic comp = pawn.GetComp<CompAbilityUserMagic>();
            List<MagicPower> listmagic = comp.MagicData.AllMagicPowers;

            foreach (var item in listmagic)
            {
                if (item.learned)
                {
                    MagicPowerSkill skillPower = comp.MagicData.GetSkill_Power((TMAbilityDef)item.abilityDef);
                    MagicPowerSkill skillEfficiency = comp.MagicData.GetSkill_Efficiency((TMAbilityDef)item.abilityDef);
                    MagicPowerSkill skillVersatility = comp.MagicData.GetSkill_Versatility((TMAbilityDef)item.abilityDef);

                    if (!(item.level >= item.maxLevel || comp.MagicData.MagicAbilityPoints == 0 || (item.costToLevel > comp.MagicData.MagicAbilityPoints)))
                    {
                        skills = skills + item.abilityDef.defName + " ";
                    }

                    if (skillPower != null && skillPower.level <= skillPower.levelMax && skillPower.costToLevel <= comp.MagicData.MagicAbilityPoints)
                    {
                        string powername = item.abilityDef.defName + "_power";
                        skills = skills + powername + " ";
                    }

                    if (skillEfficiency != null && skillEfficiency.level <= skillEfficiency.levelMax && skillEfficiency.costToLevel <= comp.MagicData.MagicAbilityPoints)
                    {
                        string powername = item.abilityDef.defName + "_efficiency";
                        skills = skills + powername + " ";
                    }


                    if (skillVersatility != null && skillVersatility.level <= skillVersatility.levelMax && skillVersatility.costToLevel <= comp.MagicData.MagicAbilityPoints)
                    {
                        string powername = item.abilityDef.defName + "_versatility";
                        skills = skills + powername + " ";
                    }
                }
            }

            return skills;
        }

        public string FindMight(Pawn pawn)
        {
            string skills = "";

            CompAbilityUserMight comp = pawn.GetComp<CompAbilityUserMight>();
            List<MightPower> listmagic = comp.MightData.AllMightPowers;

            foreach (var item in listmagic)
            {
                if (item.learned)
                {
                    MightPowerSkill skillPower = comp.MightData.GetSkill_Power((TMAbilityDef)item.abilityDef);
                    MightPowerSkill skillEfficiency = comp.MightData.GetSkill_Efficiency((TMAbilityDef)item.abilityDef);
                    MightPowerSkill skillVersatility = comp.MightData.GetSkill_Versatility((TMAbilityDef)item.abilityDef);

                    if (!(item.level >= item.maxLevel || comp.MightData.MightAbilityPoints == 0 || (item.costToLevel > comp.MightData.MightAbilityPoints)))
                    {
                        skills = skills + item.abilityDef.defName + " ";
                    }

                    if (skillPower != null && skillPower.level <= skillPower.levelMax && skillPower.costToLevel <= comp.MightData.MightAbilityPoints)
                    {
                        string powername = item.abilityDef.defName + "_power";
                        skills = skills + powername + " ";
                    }

                    if (skillEfficiency != null && skillEfficiency.level <= skillEfficiency.levelMax && skillEfficiency.costToLevel <= comp.MightData.MightAbilityPoints)
                    {
                        string powername = item.abilityDef.defName + "_efficiency";
                        skills = skills + powername + " ";
                    }


                    if (skillVersatility != null && skillVersatility.level <= skillVersatility.levelMax && skillVersatility.costToLevel <= comp.MightData.MightAbilityPoints)
                    {
                        string powername = item.abilityDef.defName + "_versatility";
                        skills = skills + powername + " ";
                    }
                }
            }

            return skills;
        }
    }

    

    public class magiclevelskill : CommandBase
    {
        public override void RunCommand(global::TwitchLib.Client.Models.Interfaces.ITwitchMessage twitchMessage)
        {
            
            Pawn pawn = GetOrFindPawn(twitchMessage.Username, false);
            if (pawn != null)
            {
                string[] messagesplit = twitchMessage.Message.Split(' ');
                if(messagesplit.Length == 1)
                {
                    return;
                }
                string skill = messagesplit[1];
                Log.Message("SASCHAHI DEBUG: " + skill);

                if (pawn.TryGetComp<CompAbilityUserMagic>().IsMagicUser)
                {
                    if (UpgradeMagicSkill(pawn, skill))
                    {
                        ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " Successfully leveled " + skill);
                        Log.Message("Saschahi: Success Magic");
                    }
                    
                }
                
                if (pawn.TryGetComp<CompAbilityUserMight>().IsMightUser)
                {
                    if (UpgradeMightSkill(pawn, skill))
                    {
                        ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " Successfully leveled " + skill);
                        Log.Message("Saschahi: Success Might");
                    }
                }
            }
            else
            {
                Log.Message("Saschahi: No Connected pawn found");
            }
        }

        public bool UpgradeMagicSkill(Pawn pawn, string skillname)
        {
            CompAbilityUserMagic comp = pawn.GetComp<CompAbilityUserMagic>();
            List<MagicPower> listmagic = comp.MagicData.AllMagicPowers;
            
            foreach(var item in listmagic)
            {
                if (item.learned)
                {
                    MagicPowerSkill skillPower = comp.MagicData.GetSkill_Power((TMAbilityDef)item.abilityDef);
                    MagicPowerSkill skillEfficiency = comp.MagicData.GetSkill_Efficiency((TMAbilityDef)item.abilityDef);
                    MagicPowerSkill skillVersatility = comp.MagicData.GetSkill_Versatility((TMAbilityDef)item.abilityDef);

                    //they have individual names but fuck it. it'll be too complicated doing it other ways
                    string powername = item.abilityDef.defName + "_power";

                    if (skillname.ToLower() == powername.ToLower())
                    {
                        if (skillPower != null && skillPower.level <= skillPower.levelMax && skillPower.costToLevel <= comp.MagicData.MagicAbilityPoints)
                        {
                            skillPower.level++;
                            comp.MagicData.MagicAbilityPoints -= skillPower.costToLevel;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //Log.Message("SASCHAHI: Subpower - " + item.abilityDef.defName + "_power");
                    }
                    powername = item.abilityDef.defName + "_efficiency";
                    if (skillname.ToLower() == powername.ToLower())
                    {
                        if (skillEfficiency != null && skillEfficiency.level <= skillEfficiency.levelMax && skillEfficiency.costToLevel <= comp.MagicData.MagicAbilityPoints)
                        {
                            skillEfficiency.level++;
                            comp.MagicData.MagicAbilityPoints -= skillEfficiency.costToLevel;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //Log.Message("SASCHAHI: Subpower - " + item.abilityDef.defName + "_efficiency");
                    }
                    powername = item.abilityDef.defName + "_versatility";
                    if (skillname.ToLower() == powername.ToLower())
                    {
                        if (skillVersatility != null && skillVersatility.level <= skillVersatility.levelMax && skillVersatility.costToLevel <= comp.MagicData.MagicAbilityPoints)
                        {
                            skillVersatility.level++;
                            comp.MagicData.MagicAbilityPoints -= skillVersatility.costToLevel;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //Log.Message("SASCHAHI: Subpower - " + item.abilityDef.defName + "_versatility");
                    }

                    if (item.abilityDef.defName.ToLower() == skillname.ToLower())
                    {
                        bool cannotupgrade = !(item.level >= item.maxLevel || comp.MagicData.MagicAbilityPoints == 0 || (item.costToLevel > comp.MagicData.MagicAbilityPoints));

                        if (cannotupgrade)
                        {
                            item.level++;
                            comp.MagicData.MagicAbilityPoints -= item.costToLevel;
                            Log.Message("SASCHAHI: Found and upgraded Skill: " + item.abilityDef.defName);
                            return true;
                        }
                        else
                        {
                            Log.Message("SASCHAHI: Failed to upgrade Skill: " + item.abilityDef.defName);
                            return false;
                        }

                    }
                }
            }
            return false;
        }

        public bool UpgradeMightSkill(Pawn pawn, string skillname)
        {
            CompAbilityUserMight comp = pawn.GetComp<CompAbilityUserMight>();
            List<MightPower> listmagic = comp.MightData.AllMightPowers;
            foreach (var item in listmagic)
            {
                if (item.learned)
                {
                    //the 3 possible "sub-upgrades" skills can have called powers
                    MightPowerSkill skillPower = comp.MightData.GetSkill_Power((TMAbilityDef)item.abilityDef);
                    MightPowerSkill skillEfficiency = comp.MightData.GetSkill_Efficiency((TMAbilityDef)item.abilityDef);
                    MightPowerSkill skillVersatility = comp.MightData.GetSkill_Versatility((TMAbilityDef)item.abilityDef);

                    //they have individual names but fuck it. it'll be too complicated doing it other ways
                    string powername = item.abilityDef.defName + "_power";

                    //checking all power upgrades
                    if (skillname.ToLower() == powername.ToLower())
                    {
                        if (skillPower != null && skillPower.level <= skillPower.levelMax && skillPower.costToLevel <= comp.MightData.MightAbilityPoints)
                        {
                            skillPower.level++;
                            comp.MightData.MightAbilityPoints -= skillPower.costToLevel;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    powername = item.abilityDef.defName + "_efficiency";
                    if (skillname.ToLower() == powername.ToLower())
                    {
                        if (skillEfficiency != null && skillEfficiency.level <= skillEfficiency.levelMax && skillEfficiency.costToLevel <= comp.MightData.MightAbilityPoints)
                        { 
                            skillEfficiency.level++;
                            comp.MightData.MightAbilityPoints -= skillEfficiency.costToLevel;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    powername = item.abilityDef.defName + "_versatility";
                    if (skillname.ToLower() == powername.ToLower())
                    {
                        if (skillVersatility != null && skillVersatility.level <= skillVersatility.levelMax && skillVersatility.costToLevel <= comp.MightData.MightAbilityPoints)
                        {
                            skillVersatility.level++;
                            comp.MightData.MightAbilityPoints -= skillVersatility.costToLevel;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    
                    //checking the main skill
                    if (item.abilityDef.defName.ToLower() == skillname.ToLower())
                    {
                        bool cannotupgrade = !(item.level >= item.maxLevel || comp.MightData.MightAbilityPoints == 0 || (item.costToLevel > comp.MightData.MightAbilityPoints));

                        if (cannotupgrade)
                        {
                            item.level++;
                            comp.MightData.MightAbilityPoints -= item.costToLevel;
                            Log.Message("SASCHAHI: Found and upgraded Skill: " + item.abilityDef.defName);
                            return true;
                        }
                        else
                        {
                            Log.Message("SASCHAHI: Failed to upgrade Skill: " + item.abilityDef.defName);
                            return false;
                        }

                    }
                }
            }
            return false;
        }

        public bool HasClass(Pawn pawn)
        {
            if (pawn.TryGetComp<CompAbilityUserMagic>()?.IsMagicUser ?? false)
            {
                return true;
            }

            return pawn.TryGetComp<CompAbilityUserMight>()?.IsMightUser ?? false;
        }
    }
}
