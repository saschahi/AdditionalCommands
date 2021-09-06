using Verse;
using TorannMagic;
using System.Collections.Generic;
using System.Linq;
using TwitchLib.Client.Models.Interfaces;

namespace AdditionalCommands
{
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

            MagicPowerSkill globalregen = comp.MagicData.MagicPowerSkill_global_regen.FirstOrDefault();
            MagicPowerSkill globaleff = comp.MagicData.MagicPowerSkill_global_eff.FirstOrDefault();
            MagicPowerSkill globalspirit = comp.MagicData.MagicPowerSkill_global_spirit.FirstOrDefault();


            if (globalregen != null && globalregen.level <= globalregen.levelMax && globalregen.costToLevel <= comp.MagicData.MagicAbilityPoints)
            {
                skills = skills + "manaregen ";
            }

            if (globaleff != null && globaleff.level <= globaleff.levelMax && globaleff.costToLevel <= comp.MagicData.MagicAbilityPoints)
            {
                skills = skills + "manaefficiency ";
            }

            if (globalspirit != null && globalspirit.level <= globalspirit.levelMax && globalspirit.costToLevel <= comp.MagicData.MagicAbilityPoints)
            {
                skills = skills + "manastorage ";
            }

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

            MightPowerSkill globalendurance = comp.MightData.MightPowerSkill_global_endurance.FirstOrDefault();
            MightPowerSkill globalrefresh = comp.MightData.MightPowerSkill_global_refresh.FirstOrDefault();
            MightPowerSkill globalseff = comp.MightData.MightPowerSkill_global_seff.FirstOrDefault();
            MightPowerSkill globalstrength = comp.MightData.MightPowerSkill_global_strength.FirstOrDefault();


            if (globalendurance != null && globalendurance.level <= globalendurance.levelMax && globalendurance.costToLevel <= comp.MightData.MightAbilityPoints)
            {
                skills = skills + "mightstorage ";
            }

            if (globalrefresh != null && globalrefresh.level <= globalrefresh.levelMax && globalrefresh.costToLevel <= comp.MightData.MightAbilityPoints)
            {
                skills = skills + "mightregen ";
            }

            if (globalseff != null && globalseff.level <= globalseff.levelMax && globalseff.costToLevel <= comp.MightData.MightAbilityPoints)
            {
                skills = skills + "mightefficiency ";
            }

            if (globalstrength != null && globalstrength.level <= globalstrength.levelMax && globalstrength.costToLevel <= comp.MightData.MightAbilityPoints)
            {
                skills = skills + "mightstrength ";
            }

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
}
