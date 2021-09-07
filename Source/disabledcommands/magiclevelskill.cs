using Verse;
using TorannMagic;
using System.Collections.Generic;
using System.Linq;
using AdditionalCommands.Helpers;

namespace AdditionalCommands.DisabledCommands
{
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
                //Log.Message("SASCHAHI DEBUG: " + skill);

                if (pawn.TryGetComp<CompAbilityUserMagic>().IsMagicUser)
                {
                    if (UpgradeMagicSkill(pawn, skill))
                    {
                        ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " Successfully leveled " + skill);
                        //Log.Message("Saschahi: Success Magic");
                    }
                    
                }
                
                if (pawn.TryGetComp<CompAbilityUserMight>().IsMightUser)
                {
                    if (UpgradeMightSkill(pawn, skill))
                    {
                        ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " Successfully leveled " + skill);
                        //Log.Message("Saschahi: Success Might");
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

            MagicPowerSkill globalregen = comp.MagicData.MagicPowerSkill_global_regen.FirstOrDefault();
            MagicPowerSkill globaleff = comp.MagicData.MagicPowerSkill_global_eff.FirstOrDefault();
            MagicPowerSkill globalspirit = comp.MagicData.MagicPowerSkill_global_spirit.FirstOrDefault();

            if (skillname.ToLower() == "manaregen")
            {
                if (globalregen != null && globalregen.level <= globalregen.levelMax && globalregen.costToLevel <= comp.MagicData.MagicAbilityPoints)
                {
                    globalregen.level++;
                    comp.MagicData.MagicAbilityPoints -= globalregen.costToLevel;
                    return true;
                }
                return false;
            }
            if(skillname.ToLower() == "manaefficiency")
            {
                if (globaleff != null && globaleff.level <= globaleff.levelMax && globaleff.costToLevel <= comp.MagicData.MagicAbilityPoints)
                {
                    globaleff.level++;
                    comp.MagicData.MagicAbilityPoints -= globaleff.costToLevel;
                    return true;
                }

                return false;
            }
            if (skillname.ToLower() == "manastorage")
            {
                if (globalspirit != null && globalspirit.level <= globalspirit.levelMax && globalspirit.costToLevel <= comp.MagicData.MagicAbilityPoints)
                {
                    globalspirit.level++;
                    comp.MagicData.MagicAbilityPoints -= globalspirit.costToLevel;
                    return true;
                }

                return false;
            }

            foreach (var item in listmagic)
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
                            //Log.Message("SASCHAHI: Found and upgraded Skill: " + item.abilityDef.defName);
                            return true;
                        }
                        else
                        {
                            //Log.Message("SASCHAHI: Failed to upgrade Skill: " + item.abilityDef.defName);
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

            MightPowerSkill globalendurance = comp.MightData.MightPowerSkill_global_endurance.FirstOrDefault();
            MightPowerSkill globalrefresh = comp.MightData.MightPowerSkill_global_refresh.FirstOrDefault();
            MightPowerSkill globalseff = comp.MightData.MightPowerSkill_global_seff.FirstOrDefault();
            MightPowerSkill globalstrength = comp.MightData.MightPowerSkill_global_strength.FirstOrDefault();

            if (skillname.ToLower() == "mightstorage")
            {
                if (globalendurance != null && globalendurance.level <= globalendurance.levelMax && globalendurance.costToLevel <= comp.MightData.MightAbilityPoints)
                {
                    globalendurance.level++;
                    comp.MightData.MightAbilityPoints -= globalendurance.costToLevel;
                    return true;
                }
                return false;
            }
            if (skillname.ToLower() == "mightregen")
            {
                if (globalrefresh != null && globalrefresh.level <= globalrefresh.levelMax && globalrefresh.costToLevel <= comp.MightData.MightAbilityPoints)
                {
                    globalrefresh.level++;
                    comp.MightData.MightAbilityPoints -= globalrefresh.costToLevel;
                    return true;
                }

                return false;
            }
            if (skillname.ToLower() == "mightefficiency")
            {
                if (globalseff != null && globalseff.level <= globalseff.levelMax && globalseff.costToLevel <= comp.MightData.MightAbilityPoints)
                {
                    globalseff.level++;
                    comp.MightData.MightAbilityPoints -= globalseff.costToLevel;
                    return true;
                }

                return false;
            }
            if (skillname.ToLower() == "mightstrength")
            {
                if (globalstrength != null && globalstrength.level <= globalstrength.levelMax && globalstrength.costToLevel <= comp.MightData.MightAbilityPoints)
                {
                    globalstrength.level++;
                    comp.MightData.MightAbilityPoints -= globalstrength.costToLevel;
                    return true;
                }

                return false;
            }

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
                            //Log.Message("SASCHAHI: Found and upgraded Skill: " + item.abilityDef.defName);
                            return true;
                        }
                        else
                        {
                            //Log.Message("SASCHAHI: Failed to upgrade Skill: " + item.abilityDef.defName);
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
