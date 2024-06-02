#include <iostream>
#include <string>
#include <vector>

using namespace std;

#ifndef MAX
#define MAX 100
#endif


long p=0;
long e=0;
struct attack{
    float att=30;
    float hp=29;
    int sh=10;
};
struct heel{
    float att=15;
    float hp=55;
    int sh=0;
    int he=2;
};
struct buff{
    int att=10;
    float hp=14;
    int sh=15;
    int bu=10;
};
struct igraci{            
  attack attac ; 
  heel heal; 
  buff build;   // Member (string variable)
} ;

/*int enemyattatt(int i){
  if (player.attac.hp>0){
           player.attac.hp -=(1-player.attac.sh/100)*enemy.attac.att;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            return 0;
           }
           else{
            game(i+1, player, enemy);
           }
           
        
        player.attac.hp +=(1-player.attac.sh/100)*enemy.attac.att;
      }
      return 1;
}
int enemyattheal(int i){
        if (player.heal.hp>0){
           player.heal.hp -=(1-player.heal.sh/100)*enemy.attac.att;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            return 0;
           }
           else{
            game(i+1, player, enemy);
           }
           player.heal.hp +=(1-player.heal.sh/100)*enemy.attac.att;
        }
        return 1;
}*/

int game(long i,igraci player,igraci enemy){
 
    float buildattac;
    float buildheal;
    if (i>8){
      return 1;
    }
    if (i%2==0)
    {
        if (player.attac.hp>0 && enemy.attac.hp>0){
           player.attac.hp -=(1-player.attac.sh/100)*enemy.attac.att;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            
            p++;
           }
           else{
            game(i+1, player, enemy);
            
           }
           
        
        player.attac.hp +=(1-player.attac.sh/100)*enemy.attac.att;
        if(i==0){
          cout<<p<<endl<<e<<"attatt"<<endl;
          p=0;
          e=0;
        }
      }

        if (player.heal.hp>0 && enemy.attac.hp>0){
           player.heal.hp -=(1-player.heal.sh/100)*enemy.attac.att;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
           player.heal.hp +=(1-player.heal.sh/100)*enemy.attac.att;
           if(i==0){
          cout<<p<<endl<<e<<"atth"<<endl;
          p=0;
          e=0;
        }
        }
        

         if (player.build.hp>0 && enemy.attac.hp>0){
           player.build.hp -=(1-player.build.sh/100)*enemy.attac.att;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
           player.build.hp +=(1-player.build.sh/100)*enemy.attac.att;
           if(i==0){
          cout<<p<<endl<<e<<"attb"<<endl;
          p=0;
          e=0;
        }
        }
        







        if (player.attac.hp>0 && enemy.heal.hp>0){
           player.attac.hp -=(1-player.attac.sh/100)*enemy.heal.att;
           enemy.attac.hp+=enemy.heal.he;
           enemy.build.hp+=enemy.heal.he;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
           player.attac.hp +=(1-player.attac.sh/100)*enemy.heal.att;
        enemy.attac.hp-=enemy.heal.he;
        enemy.build.hp-=enemy.heal.he;
        if(i==0){
          cout<<p<<endl<<e<<"ha"<<endl;
          p=0;
          e=0;
        }
        }
        


        if (player.heal.hp>0 && enemy.heal.hp>0){
           player.heal.hp -=(1-player.heal.sh/100)*enemy.heal.att;
           enemy.attac.hp+=enemy.heal.he;
           enemy.build.hp+=enemy.heal.he;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
           player.heal.hp +=(1-player.heal.sh/100)*enemy.heal.att;
        enemy.attac.hp-=enemy.heal.he;
        enemy.build.hp-=enemy.heal.he;
        if(i==0){
          cout<<p<<endl<<e<<"hh"<<endl;
          p=0;
          e=0;
        }
        }
        

         if (player.build.hp>0 && enemy.heal.hp>0){
           player.build.hp -=(1-player.build.sh/100)*enemy.heal.att;
            enemy.attac.hp-=enemy.heal.he;
            enemy.build.hp-=enemy.heal.he;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
           player.build.hp +=(1-player.build.sh/100)*enemy.attac.att;
        enemy.attac.hp-=enemy.heal.he;
        enemy.build.hp-=enemy.heal.he;

        if(i==0){
          cout<<p<<endl<<e<<"hb"<<endl;
          p=0;
          e=0;
        }
        }
        



        
        if (player.attac.hp>0 && enemy.build.hp>0){
           player.attac.hp -=(1-player.attac.sh/100)*enemy.build.att;
           buildattac=enemy.attac.att*(enemy.build.bu/100);
           enemy.attac.att+=buildattac;
           buildheal=enemy.heal.att*(enemy.build.bu/100);
           enemy.heal.att+=buildheal;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
           player.attac.hp +=(1-player.attac.sh/100)*enemy.build.att;
           enemy.attac.att-=buildattac;
           enemy.heal.att-=buildheal;
        if(i==0){
          cout<<p<<endl<<e<<"ba"<<endl;
          p=0;
          e=0;
        }
        }
        



        if (player.heal.hp>0 && enemy.build.hp>0){
           player.heal.hp -=(1-player.heal.sh/100)*enemy.build.att;
           buildattac=enemy.attac.att*(enemy.build.bu/100);
           enemy.attac.att+=buildattac;
           buildheal=enemy.heal.att*(enemy.build.bu/100);
           enemy.heal.att+=buildheal;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
            player.heal.hp +=(1-player.heal.sh/100)*enemy.heal.att;
       enemy.attac.att-=buildattac;
        enemy.heal.att-=buildheal;
        if(i==0){
          cout<<p<<endl<<e<<"bh"<<endl;
          p=0;
          e=0;
        }
        }
       

         if (player.build.hp>0 && enemy.build.hp>0){
           player.build.hp -=(1-player.build.sh/100)*enemy.build.att;
           buildattac=enemy.attac.att*(enemy.build.bu/100);
           enemy.attac.att+=buildattac;
           buildheal=enemy.heal.att*(enemy.build.bu/100);
           enemy.heal.att+=buildheal;
           if (player.attac.hp<=0&&player.heal.hp<=0&&player.build.hp<=0){
            //cout<<i<<endl;
            p++;
           }
           else{
            game(i+1, player, enemy);
           }
           player.build.hp +=(1-player.build.sh/100)*enemy.attac.att;
        enemy.attac.att-=buildattac;
        enemy.heal.att-=buildheal;
        if(i==0){
          cout<<p<<endl<<e<<"bb"<<endl;
          p=0;
          e=0;
        }
        }
        


        
    }

    else{
        if (enemy.attac.hp>0 && player.attac.hp>0){
           enemy.attac.hp -=(1-enemy.attac.sh/100)*player.attac.att;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.attac.hp +=(1-enemy.attac.sh/100)*player.attac.att;
        }
        


        if (enemy.heal.hp>0 && player.attac.hp>0){
           enemy.heal.hp -=(1-enemy.heal.sh/100)*player.attac.att;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.heal.hp +=(1-enemy.heal.sh/100)*player.attac.att;
        }
        

         if (enemy.build.hp>0 && player.attac.hp>0){
           enemy.build.hp -=(1-enemy.build.sh/100)*player.attac.att;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.build.hp +=(1-enemy.build.sh/100)*player.attac.att;
        }
        







        if (enemy.attac.hp>0 && player.heal.hp>0){
           enemy.attac.hp -=(1-enemy.attac.sh/100)*player.heal.att;
           player.attac.hp+=player.heal.he;
           player.build.hp+=player.heal.he;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.attac.hp +=(1-enemy.attac.sh/100)*player.heal.att;
        player.attac.hp-=player.heal.he;
        player.build.hp-=player.heal.he;
        }
        


        if (enemy.heal.hp>0 && player.heal.hp>0){
           enemy.heal.hp -=(1-enemy.heal.sh/100)*player.heal.att;
           player.attac.hp+=player.heal.he;
           player.build.hp+=player.heal.he;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.heal.hp +=(1-enemy.heal.sh/100)*player.heal.att;
        player.attac.hp-=player.heal.he;
        player.build.hp-=player.heal.he;
        }
        

         if (enemy.build.hp>0 && player.heal.hp>0){
           enemy.build.hp -=(1-enemy.build.sh/100)*player.heal.att;
            player.attac.hp-=player.heal.he;
            player.build.hp-=player.heal.he;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
            enemy.build.hp +=(1-enemy.build.sh/100)*player.attac.att;
        player.attac.hp-=player.heal.he;
        player.build.hp-=player.heal.he;
        }
       





        if (enemy.attac.hp>0 && player.build.hp>0){
           enemy.attac.hp -=(1-enemy.attac.sh/100)*player.build.att;
           buildattac=player.attac.att*(player.build.bu/100);
           player.attac.att+=buildattac;
           buildheal=player.heal.att*(player.build.bu/100);
           player.heal.att+=buildheal;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.attac.hp +=(1-enemy.attac.sh/100)*player.build.att;
        player.attac.att-=buildattac;
        player.heal.att-=buildheal;
        }
        



        if (enemy.heal.hp>0 && player.build.hp>0){
           enemy.heal.hp -=(1-enemy.heal.sh/100)*player.build.att;
           buildattac=player.attac.att*(player.build.bu/100);
           player.attac.att+=buildattac;
           buildheal=player.heal.att*(player.build.bu/100);
           player.heal.att+=buildheal;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.heal.hp +=(1-enemy.heal.sh/100)*player.heal.att;
        player.attac.att-=buildattac;
        player.heal.att-=buildheal;
        }
        

         if (enemy.build.hp>0 && player.build.hp>0){
           enemy.build.hp -=(1-enemy.build.sh/100)*player.build.att;
           buildattac=player.attac.att*(player.build.bu/100);
           player.attac.att+=buildattac;
           buildheal=player.heal.att*(player.build.bu/100);
           player.heal.att+=buildheal;
           if (enemy.attac.hp<=0&&enemy.heal.hp<=0&&enemy.build.hp<=0){
            //cout<<i<<endl;
            e++;
           }
           else{
            game(i+1, player, enemy);
           }
           enemy.build.hp +=(1-enemy.build.sh/100)*player.attac.att;
        player.attac.att-=buildattac;
        player.heal.att-=buildheal;
        }
        
    }

            
    return 1;
}







int main(){
    


    long i =0;
    igraci player,enemy;
    game(i, player, enemy);
    cout<<p<<endl<<e<<endl;
    return 0;
    
    
}





