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
        UserManager = 0,
        CarShipManager = 1,
        ProjectManager = 2,
        GoodsManager=3,
    }

}
