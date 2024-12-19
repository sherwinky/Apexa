
import { ChangeDetectionStrategy, Component,OnInit, ViewChild} from '@angular/core';
import { ListSearchResult } from '../../models/list-search-result.model';
import { Advisor } from '../../models/advisor.model';
import { AdvisorService } from '../../services/advisor.service';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
@Component({
  selector: 'app-advisor-list',
  templateUrl: './advisor-list.component.html',
  styleUrl: './advisor-list.component.less'
})
export class AdvisorListComponent  implements OnInit  {
  loading = true;
  dataSource :any;
  searchResult: ListSearchResult= new ListSearchResult();
  advisorList: Advisor[] = [];
  nameInvalid: boolean = true;
  advisorName: string;
  colorDic:any= {};

  displayedColumns: string[] = ['FullName',"Sin","Address","PhoneNumber","Status","Action"];
    constructor(private advisorService: AdvisorService) {
        this.advisorName = '';
        this.colorDic[0] = "green";
        this.colorDic[1] = "yellow";
        this.colorDic[2] = "red";
  }
  ngOnInit() {
    this.initData();
  }
  initData() {
    this.searchResult = new ListSearchResult();
    this.searchResult.result = [];
    this.advisorList = [];

  }
  getData() {
    this.advisorService.searchAdvisor(this.advisorName).subscribe((data: any) => {
      this.handleErrorResponse(data);
      this.loading = false;
      this.searchResult = data;
      this.advisorList = this.searchResult.result;
      this.dataSource = this.advisorList
    });
  }
  searchButtonClicked(event:any){
    this.getData();
  }
  deleteClick(event:any,id:number){
    if(confirm("Please confirm delete the record.")){
      this.advisorService.deleteAdvisor(id).subscribe((data:any)=>{
        this.getData();
      });
    }
  }
  handleErrorResponse(data: ListSearchResult){
    if(!data.success){
      data.result=[];
    }
  }
}

