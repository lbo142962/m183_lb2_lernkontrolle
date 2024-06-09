import './SinglePage.css';
import img from "./../../../../Images/PlaceHolder.jpg"
import { IFilmlist } from '../../../../Interfaces';

const FilmList = (props: IFilmlist) => {
    return(
        <>
        <div className="personList">
        <form>
            <div className='mainDiv'>
                <div>
                    <img className='images-Film' src={img} alt="" />
                </div>
                <div >
                    <div>
                    <label>{props.name}</label>
                    <label>{props.releaseYear}</label>
                    <label>{props.rating}</label>
                    </div>
                </div>
            </div>
       </form>
        </div>

        </>

    );

}
export default FilmList;