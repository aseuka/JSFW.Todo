using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace JSFW.NPT.Controls
{
    [DefaultEvent("DaySelected")]
    public partial class ScheduleCalendarControl : UserControl
    {
        Dictionary<RadioButton, string> TooltipList = new Dictionary<RadioButton, string>();

        internal DateTime CurrentDate = DateTime.Today;
        DateTime FromDate;
        DateTime ToDate;

        int prevWeekCount = -1;
        int thisWeekCount = 0;
        int NextWeekCount = 1;

        bool IsLoaded = false;
         
        public ScheduleCalendarControl()
        {
            InitializeComponent(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //foreach (RadioButton rdo in DaysPanel.Controls)
            //{
            //    TooltipList.Add(rdo, "");
            //}
            // 처음 로딩할때 초기값은 Today!
            IsLoaded = true;
            SetDate(CurrentDate);
            //IsLoaded = true;

            //SelectAllButton.Width = 0;
            this.Disposed += ScheduleCalendarControl_Disposed;
        }

        private void ScheduleCalendarControl_Disposed(object sender, EventArgs e)
        {
            TooltipList.Clear();
            TooltipList = null;
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            // todo : 오늘 선택 ( 기간 오늘이 포함된 주로 셋팅. )
            // 전주, 금주, 차주 표시 처리에 필요한 값 초기화.
            prevWeekCount = -1;
            thisWeekCount = 0;
            NextWeekCount = 1;
            SetDate(DateTime.Today);
        }

        internal void SetDate(DateTime currentDate)
        {
            CurrentDate = currentDate;

            Rendering();

            RadioButton rdoCurrentDay = null;
            foreach (RadioButton rdo in DaysPanel.Controls)
            {
                if (("" + rdo.Tag) == CurrentDate.ToShortDateString())
                {
                    rdoCurrentDay = rdo;
                    break;
                }
            }

            SetWeekButton(null);

            SetCurrentDay(rdoCurrentDay);

            OnDaySelected(!IsLoaded, RangeType.Day, "" + rdoCurrentDay.Tag, "" + rdoCurrentDay.Tag);
        }

        private void CalcFromToDate()
        {
            // todo : 3주~ 모두 표시를 위해 계산.
            // 한주를 일요일부터 시작 
            //  (일요일2) << (일요일1) << 오늘.AddDays(1) : 금주
            //  시작일 >> 토요일1 >> 토요일2 >> 토요일3 
            bool isSetFromDate = false;
            int cnt = 0;
            FromDate = CurrentDate.AddDays(1);
            do
            {
                FromDate = FromDate.AddDays(-1);
                if (FromDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    cnt++;
                }
                if (cnt == 2)
                {
                    isSetFromDate = true;
                }
             
            } while (!isSetFromDate);

            bool isSetToDate = false;
            cnt = 0;
            ToDate = FromDate;
            do
            {
                ToDate = ToDate.AddDays(+1);
                if (ToDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    cnt++;
                }
                if (cnt == 3)
                {
                    isSetToDate = true;
                }
            } while (!isSetToDate);
        }

        private void PrevWeekButton_Click(object sender, EventArgs e)
        {
            // todo : 전주 이동
            prevWeekCount -= 1;
            thisWeekCount -= 1;
            NextWeekCount -= 1;

            CurrentDate = CurrentDate.AddDays(-7);
            Rendering();
            SetCurrentDay(null);
            OnDaySelected(false, RangeType.Week, $"{FromDate:yyyy-MM-dd}", $"{FromDate.AddDays(+6):yyyy-MM-dd}");
           // SetWeekButton(null);
        }

        private void NextWeekButton_Click(object sender, EventArgs e)
        {
            // todo : 차주 이동 
            prevWeekCount += 1;
            thisWeekCount += 1;
            NextWeekCount += 1;

            CurrentDate = CurrentDate.AddDays(+7);
            Rendering();
            SetCurrentDay(null);
            OnDaySelected(false, RangeType.Week, $"{FromDate:yyyy-MM-dd}", $"{FromDate.AddDays(+6):yyyy-MM-dd}");
          //  SetWeekButton(null);
        }

        private void Rendering()
        {
            CalcFromToDate();
            // 기간 표시
            YearMonthLabel.Text = string.Format("{0:yyyy.MM.dd} ~ {1:yyyy.MM.dd}", FromDate, ToDate);

            // YearMonth 라벨처리.
            MainYearMonthLabel.Visible = true;
            SubYearMonthLabel.Visible = !(FromDate.Year == ToDate.Year && FromDate.Month == ToDate.Month);

            MainYearMonthLabel.Text = string.Format("{0:yyyy.MM}", FromDate);
            SubYearMonthLabel.Text = string.Format("{0:yyyy.MM}", ToDate);

            DateTime tmp = FromDate;
            MainYearMonthLabel.Width = 0;
            MainYearMonthLabel.Left = 1;
            SubYearMonthLabel.Width = 0;
            SubYearMonthLabel.Left = this.Width;

            SortedList<DateTime, string> holidays = GetDayHolidays( tmp.Year );

            for (int loop = 1; loop <= 21; loop++)
            {
                Control[] ctrls = DaysPanel.Controls.Find("rdo_" + loop.ToString("D2"), false);
                if (ctrls != null && 0 < ctrls.Length)
                {
                    RadioButton rdo = ctrls.First() as RadioButton;
                    TooltipList[rdo] = "";

                    rdo.Text = "" + tmp.Day;
                    rdo.Tag = string.Format("{0:yyyy-MM-dd}", tmp);
                    rdo.BackColor = Color.White;
                    rdo.ForeColor = Color.Black;
                    rdo.Font = new Font(rdo.Font, FontStyle.Regular);

                    if (tmp.Year != FromDate.Year) {
                        holidays = GetDayHolidays(tmp.Year);
                    }
                    
                   
                     
                    {
                        // 토요일
                        if (tmp.DayOfWeek == DayOfWeek.Saturday)
                        {
                            rdo.ForeColor = Color.Blue;                            
                        }

                        // 휴일인경우
                        if (holidays.Keys.Contains( tmp ))
                        {
                            rdo.Font = new Font(rdo.Font, FontStyle.Bold);
                            rdo.ForeColor = Color.Red;                            
                            TooltipList[rdo] = holidays[tmp]; 
                        }
                        else 
                        if (tmp.DayOfWeek == DayOfWeek.Sunday)
                        {
                            rdo.ForeColor = Color.Red;
                        }
                    }

                    //오늘인 경우 배경색!
                    if (tmp.ToShortDateString() == DateTime.Today.ToShortDateString())
                    {
                        //  rdo.BackColor = Color.ForestGreen;
                        // rdo.ForeColor = Color.White;
                        rdo.Font = new Font(rdo.Font, FontStyle.Bold | FontStyle.Underline);
                    }

                    if (tmp.Month == FromDate.Month)
                    {
                        // 달 체크..
                        MainYearMonthLabel.Width += rdo.Width;
                    }
                    else
                    {
                        if (rdo.Left < SubYearMonthLabel.Left)
                        {
                            MainYearMonthLabel.Width -= 2;
                            MainYearMonthLabel.BorderStyle = BorderStyle.FixedSingle;
                            SubYearMonthLabel.Left = rdo.Left;
                            SubYearMonthLabel.BorderStyle = BorderStyle.FixedSingle;
                        }
                        SubYearMonthLabel.Width += rdo.Width - 1;
                        SubYearMonthLabel.Visible = true;
                    }
                    tmp = tmp.AddDays(1);
                }
            }
            SubYearMonthLabel.Width += 1;
            if (SubYearMonthLabel.Visible == false)
            {
                MainYearMonthLabel.Width -= 20;
            }

            switch (prevWeekCount)
            {
                default:
                    PrevWeekViewButton.Text = prevWeekCount + "주";
                    break;
                case -1:
                    PrevWeekViewButton.Text = "전주";
                    break;
                case 1:
                    PrevWeekViewButton.Text = "차주";
                    break;
                case 0:
                    PrevWeekViewButton.Text = "금주";
                    break;
            }
            switch (thisWeekCount)
            {
                default:
                    ThisWeekViewButton.Text = thisWeekCount + "주";
                    break;
                case -1:
                    ThisWeekViewButton.Text = "전주";
                    break;
                case 1:
                    ThisWeekViewButton.Text = "차주";
                    break;
                case 0:
                    ThisWeekViewButton.Text = "금주";
                    break;
            }

            switch (NextWeekCount)
            {
                default:
                    NextWeekViewButton.Text = NextWeekCount + "주";
                    break;
                case -1:
                    NextWeekViewButton.Text = "전주";
                    break;
                case 1:
                    NextWeekViewButton.Text = "차주";
                    break;
                case 0:
                    NextWeekViewButton.Text = "금주";
                    break;
            } 
        }

        public event CalendarSelected DaySelected = null;

        protected virtual void OnDaySelected(bool isRangeChanged, RangeType range, string fromDay, string toDay)
        {
            if (isRangeChanged) return;
            // todo : year, month, + day 
            if (DaySelected != null) DaySelected(range, fromDay, toDay);
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            // todo : Select All
            SetCurrentDay(null);
            SetWeekButton(SelectAllButton);
            OnDaySelected(false, RangeType.All, "", "");
        }

        RadioButton RadioCurrentDay { get; set; }

        private void SetCurrentDay(RadioButton rdo)
        {
            if (RadioCurrentDay != null)
            {
                RadioCurrentDay.FlatAppearance.BorderSize = 1; 
                //RadioCurrentDay.FlatAppearance.BorderColor = Color.DodgerBlue;
                RadioCurrentDay.BackColor = Color.White;  
            }
            RadioCurrentDay = rdo;
            if (RadioCurrentDay != null)
            {
                RadioCurrentDay.FlatAppearance.BorderSize = 3;
                //RadioCurrentDay.FlatAppearance.BorderColor = Color.OrangeRed;
            }
        }

        private void rdo_DayCheckedChanged(object sender, EventArgs e)
        {
            // todo : 선택일자. 
            SetWeekButton(null);

            RadioButton rdoDay = sender as RadioButton;
            if (rdoDay.Checked)
            {
                SetCurrentDay(rdoDay); 
                OnDaySelected(false, RangeType.Day, "" + rdoDay.Tag, "" + rdoDay.Tag);
            }
        }

        private void rdo_MouseHover(object sender, EventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo != null)
            {
                if (!string.IsNullOrEmpty(("" + TooltipList[rdo]).Trim()))
                {
                    toolTip1.SetToolTip(rdo, TooltipList[rdo]);
                }
            }
        }

        private void PrevWeekViewButton_Click(object sender, EventArgs e)
        {
            // todo : 전주 
            SetWeekButton(PrevWeekViewButton);
            OnDaySelected(false, RangeType.Week, ""+rdo_01.Tag, ""+ rdo_07.Tag);
        }
         
        private void ThisWeekViewButton_Click(object sender, EventArgs e)
        {
            // todo : 금주
            SetWeekButton(ThisWeekViewButton);
            OnDaySelected(false, RangeType.Week, "" + rdo_08.Tag, "" + rdo_14.Tag);
        }

        private void NextWeekViewButton_Click(object sender, EventArgs e)
        {
            // todo : 차주
            SetWeekButton(NextWeekViewButton);
            OnDaySelected(false, RangeType.Week, "" + rdo_15.Tag, "" + rdo_21.Tag);
        }
         
        private void SetWeekButton(Button viewButton)
        {
            if (viewButton != null && RadioCurrentDay != null)
            {
                SetCurrentDay(null); 
            }

            if (PrevWeekViewButton.Equals(viewButton))
            {
                PrevWeekViewButton.FlatAppearance.BorderSize = 2;
            }
            else
            {
                PrevWeekViewButton.FlatAppearance.BorderSize = 1;
            }

            if (ThisWeekViewButton.Equals(viewButton))
            {
                ThisWeekViewButton.FlatAppearance.BorderSize = 2;
            }
            else
            {
                ThisWeekViewButton.FlatAppearance.BorderSize = 1;
            }

            if (NextWeekViewButton.Equals(viewButton))
            {
                NextWeekViewButton.FlatAppearance.BorderSize = 2;
            }
            else
            {
                NextWeekViewButton.FlatAppearance.BorderSize = 1;
            }
             
            if (SelectAllButton.Equals(viewButton))
            {
                SelectAllButton.FlatAppearance.BorderSize = 2;
            }
            else
            {
                SelectAllButton.FlatAppearance.BorderSize = 1;
            }
        }

        private SortedList<DateTime, string> GetDayHolidays(int year)
        {
            //휴일  
            SortedList<DateTime, string> holidays = new SortedList<DateTime, string>();
            //( 양력 )
            holidays.Add(new DateTime(year, 1, 1), "신정"); // 신정
            holidays.Add(new DateTime(year, 3, 1), "3.1절"); // 3.1절(5대 국경일)
            holidays.Add(new DateTime(year, 5, 5), "어린이날"); // 어린이날
            holidays.Add(new DateTime(year, 6, 6), "현충일"); // 현충일
            //holidays.Add(new DateTime(year, 7, 17), "제헌절"); // 제헌절 (5대 국경일, 휴일에서 제외됨)
            holidays.Add(new DateTime(year, 8, 15), "광복절"); // 광복절 (5대 국경일) 
            holidays.Add(new DateTime(year, 10, 3), "개천절"); // 개천절(5대 국경일)
            holidays.Add(new DateTime(year, 10, 9), "한글날"); // 한글날(5대 국경일)
            holidays.Add(new DateTime(year, 12, 25), "크리스마스"); // 크리스마스
            //음력
            KoreanLunisolarCalendar kc = new KoreanLunisolarCalendar();
            //설
            holidays.Add(kc.ToDateTime(year, 1, 1, 0, 0, 0, 0), "설");
            holidays.Add(kc.ToDateTime(year, 1, 1, 0, 0, 0, 0).AddDays(-1), "설(전)");
            holidays.Add(kc.ToDateTime(year, 1, 1, 0, 0, 0, 0).AddDays(+1), "설(후)");
            //석가탄신일
            holidays.Add(kc.ToDateTime(year, 4, 8, 0, 0, 0, 0), "석가탄신일");
            //추석
            holidays.Add(kc.ToDateTime(year, 8, 15, 0, 0, 0, 0), "추석");
            holidays.Add(kc.ToDateTime(year, 8, 15, 0, 0, 0, 0).AddDays(-1), "추석(전)");
            holidays.Add(kc.ToDateTime(year, 8, 15, 0, 0, 0, 0).AddDays(+1), "추석(후)");
            return holidays;
        }

        private void rdo_DayCheckedChanged(object sender, MouseEventArgs e)
        {
            RadioButton rdo = sender as RadioButton;
            if (rdo != null)
                rdo.Checked = !rdo.Checked;
        }
    }

    public enum RangeType {
        Day,
        Week,
        All
    }
    public delegate void CalendarSelected(RangeType range, string from, string to);
}
