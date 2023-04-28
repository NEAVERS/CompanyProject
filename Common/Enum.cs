using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Sex
    {
        女 = 0,
        男
    }

    public enum CheckSub
    {
          公厕周边 =1,
          外墙面,
          镜子,
          洗手池台面,
          洗手池,
          公厕标牌,
          采光照明,
          天花板,
          内墙面,
          地面,
          门窗,
          隔板,
          小便器,
          大便厕位,
          管理房,
          无障碍间,
          用水系统,
          消防通道,
          用电系统,
          环境卫生,
          违禁品
    }


    public enum PermissionList
    {
        用户管理 = 0,
        人员管理 = 1,
        车船管理 = 2,
        建筑垃圾 = 3,
        招标管理 = 4,
        项目管理 = 5,
        物资管理 = 6,
        后勤管理 = 7,
        采购管理 = 8,

        用户信息编辑 = 10,
        人员信息编辑 = 11,
        车船信息编辑 = 12,
        招标信息编辑 = 13,
        项目信息编辑 = 14,
        物资信息编辑 = 15,
        后勤信息编辑 = 16,


        招标爬虫信息编辑 = 20,
        申请采购 = 21,
        审批采购 = 22,





    }

}
